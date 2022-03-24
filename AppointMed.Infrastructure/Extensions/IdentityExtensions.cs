using Microsoft.AspNetCore.Http;

namespace AppointMed.Infrastructure.Extensions;

public static class IdentityExtensions
{
    public static string GetUserId(this HttpContext httpContext)
    {
        if(httpContext.User == null)
            return string.Empty;

        return httpContext.User.Claims.Single(x => x.Type == "id").Value;
    }
}
