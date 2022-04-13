using AppointMed.Core.Entities.AuthAggregate;
using AppointMed.Core.Interfaces;
using AppointMed.Infrastructure.Data;
using AppointMed.Infrastructure.Settings;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace AppointMed.Infrastructure.Services.Auth;

public class IdentityService : IIdentityService
{
    private readonly UserManager<IdentityUser> _userManager;
    private readonly RoleManager<IdentityRole> _roleManager;
    private readonly JwtSettings _jwtSettings;
    private readonly TokenValidationParameters _tokenValidationParameters;
    private readonly DataContext _dataContext;

    public IdentityService(UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager, JwtSettings jwtSettings,
        TokenValidationParameters tokenValidationParameters, DataContext dataContext)
    {
        _userManager = userManager;
        _roleManager = roleManager;
        _jwtSettings = jwtSettings;
        _tokenValidationParameters = tokenValidationParameters;
        _dataContext = dataContext;

    }

    public async Task<AuthenticationResult> RegisterAsync(string email, string password, string role)
    {
        var existingUser = await _userManager.FindByEmailAsync(email);

        if (existingUser is not null)
            return new AuthenticationResult
            {
                Errors = new[] { "User with this email address already exists" }
            };

        var newUser = new IdentityUser
        {
            Id = Guid.NewGuid().ToString(),
            Email = email,
            UserName = email
        };

        var result = await _userManager.CreateAsync(newUser, password);

        if (!result.Succeeded)
            return new AuthenticationResult
            {
                Success = false,
                Errors = result.Errors.Select(x => x.Description)
            };

        if (role == "Patient")
            await this._userManager.AddToRoleAsync(newUser,Policies.Roles.Patient);
        else if (role == "Doctor")
            await this._userManager.AddToRoleAsync(newUser, Policies.Roles.Doctor);
        else
            return new AuthenticationResult
            {
                Success = false,
                Errors = new[] { "You have selected an invalid role" }
            };

        return await GenerateAuthenticationResultForUserAsync(newUser);
    }

    public async Task<AuthenticationResult> LoginAsync(string email, string password)
    {
        var user = await _userManager.FindByEmailAsync(email);

        if (user is null)
            return new AuthenticationResult
            {
                Success = false,
                Errors = new[] { "A user with this email address does not exist" }
            };

        var result = await _userManager.CheckPasswordAsync(user, password);

        if (!result)
            return new AuthenticationResult
            {
                Success = false,
                Errors = new[] { "The email/password combination is incorrect" }
            };

        return await GenerateAuthenticationResultForUserAsync(user);
    }

    private async Task<AuthenticationResult> GenerateAuthenticationResultForUserAsync(IdentityUser user)
    {
        var jwtToken = await this.CreateJwtToken(user);

        var refreshToken = new RefreshToken
        {
            JwtId = jwtToken.Id,
            UserId = user.Id,
            CreationDate = DateTime.UtcNow,
            ExpiryDate = DateTime.UtcNow.AddMonths(6)
        };

        this._dataContext.RefreshTokens.Add(refreshToken);
        var numSaved = await this._dataContext.SaveChangesAsync();

        if (numSaved == 0)
        {
            return new AuthenticationResult
            {
                Success = false,
                Errors = new[] { "Failed to save refresh token to database" }
            };
        }

        return new AuthenticationResult
        {
            Success = true,
            Token = new JwtSecurityTokenHandler().WriteToken(jwtToken),
            RefreshToken = refreshToken.Token,
            UserId = user.Id,
        };
    }

    private async Task<SecurityToken> CreateJwtToken(IdentityUser user)
    {
        var tokenHandler = new JwtSecurityTokenHandler();
        var key = Encoding.ASCII.GetBytes(this._jwtSettings.Secret);
        var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.Email),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Email, user.Email),
                new Claim("id", user.Id),
            };

        //var userClaims = await this._userManager.GetClaimsAsync(user);
        //claims.AddRange(userClaims);

        var userRoleClaims = await GetUserRoleClaimsAsync(user, claims);
        claims.AddRange(userRoleClaims);

        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(claims),
            Expires = DateTime.UtcNow.Add(_jwtSettings.TokenLifetime),
            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
        };

        return tokenHandler.CreateToken(tokenDescriptor);
    }

    public async Task<AuthenticationResult> RefreshTokenAsync(string token, string refreshToken)
    {
        var validatedToken = GetPrincipalFromToken(token);

        if (validatedToken is null)
            return new AuthenticationResult { Errors = new[] { "Invalid token." } };

        var expiryDateUnix = long.Parse(validatedToken.Claims.Single(x => x.Type == JwtRegisteredClaimNames.Exp).Value);

        var expiryDateTimeUtc = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)
            .AddSeconds(expiryDateUnix);

        if (expiryDateTimeUtc > DateTime.UtcNow)
            return new AuthenticationResult { Errors = new[] { "This token hasn't expired yet." } };

        var jti = validatedToken.Claims.Single(x => x.Type == JwtRegisteredClaimNames.Jti).Value;

        var storedRefreshToken = await _dataContext.RefreshTokens.SingleOrDefaultAsync(x => x.Token == refreshToken);

        if (storedRefreshToken is null)
            return new AuthenticationResult { Errors = new[] { "This refresh token does not exist." } };

        if (DateTime.UtcNow > storedRefreshToken.ExpiryDate)
            return new AuthenticationResult { Errors = new[] { "This refresh token has expired." } };

        if (storedRefreshToken.Invalidated)
            return new AuthenticationResult { Errors = new[] { "This refresh token has been invalidated." } };

        if (storedRefreshToken.Used)
            return new AuthenticationResult { Errors = new[] { "This refresh token has been used." } };

        if (storedRefreshToken.JwtId != jti)
            return new AuthenticationResult { Errors = new[] { "This refresh token does not match the JWT." } };

        storedRefreshToken.Used = true;

        _dataContext.RefreshTokens.Update(storedRefreshToken);
        await _dataContext.SaveChangesAsync();

        var user = await _userManager.FindByIdAsync(validatedToken.Claims.Single(x => x.Type == "id").Value);

        return await GenerateAuthenticationResultForUserAsync(user);
    }

    private ClaimsPrincipal GetPrincipalFromToken(string token)
    {
        var tokenHandler = new JwtSecurityTokenHandler();

        try
        {
            var principal = tokenHandler.ValidateToken(token, _tokenValidationParameters, out var validatedToken);
            if (!IsJwtWithValidSecurityAlgorithm(validatedToken))
                return null;
            return principal;
        }
        catch
        {
            return null;
        }
    }

    private static bool IsJwtWithValidSecurityAlgorithm(SecurityToken validatedToken)
    {
        return validatedToken is JwtSecurityToken jwtSecurityToken &&
            jwtSecurityToken.Header.Alg.Equals(SecurityAlgorithms.HmacSha256,
            StringComparison.InvariantCultureIgnoreCase);
    }

    private async Task<List<Claim>> GetUserRoleClaimsAsync(IdentityUser user, List<Claim> existingClaims)
    {
        var userRoleClaims = new List<Claim>();
        var userRoles = await this._userManager.GetRolesAsync(user);

        foreach (var userRole in userRoles)
        {
            userRoleClaims.Add(new Claim(ClaimTypes.Role, userRole));
            var role = await this._roleManager.FindByNameAsync(userRole);

            if (role == null)
            {
                continue;
            }

            var roleClaims = await this._roleManager.GetClaimsAsync(role);

            foreach (var roleClaim in roleClaims)
            {
                if (existingClaims.Contains(roleClaim) || userRoleClaims.Contains(roleClaim))
                {
                    continue;
                }

                userRoleClaims.Add(roleClaim);
            }
        }

        return userRoleClaims;
    }
}
