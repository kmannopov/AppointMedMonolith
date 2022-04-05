using Microsoft.AspNetCore.Http;

namespace AppointMed.Infrastructure.Extensions;

public static class IdentityExtensions
{
    public static Guid GetUserId(this HttpContext httpContext)
    {
        if(httpContext.User == null)
            return Guid.Empty;

        return Guid.Parse(httpContext.User.Claims.Single(x => x.Type == "id").Value);
    }
}
