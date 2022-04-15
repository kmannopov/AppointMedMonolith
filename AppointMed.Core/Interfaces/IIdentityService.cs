using AppointMed.Core.Entities.AuthAggregate;

namespace AppointMed.Core.Interfaces;

public interface IIdentityService
{
    Task<AuthenticationResult> RegisterAsync(string email, string password, string role);
    Task<AuthenticationResult> LoginAsync(string email, string password);
    Task<AuthenticationResult> RefreshTokenAsync(string token, string refreshToken);
}
