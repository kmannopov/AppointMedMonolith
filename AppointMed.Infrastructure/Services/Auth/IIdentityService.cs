using AppointMed.Infrastructure.Entities.AuthAggregate;

namespace AppointMed.Infrastructure.Services.Auth;

public interface IIdentityService
{
    Task<AuthenticationResult> RegisterAsync(string email, string password);
    Task<AuthenticationResult> LoginAsync(string email, string password);
    Task<AuthenticationResult> RefreshTokenAsync(string token, string refreshToken);
}
