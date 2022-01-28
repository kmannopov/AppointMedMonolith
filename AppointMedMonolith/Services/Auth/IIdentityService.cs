using AppointMed.Core.Entities.AuthAggregate;

namespace AppointMed.API.Services.Auth;

public interface IIdentityService
{
    Task<AuthenticationResult> RegisterAsync(string email, string password);
}
