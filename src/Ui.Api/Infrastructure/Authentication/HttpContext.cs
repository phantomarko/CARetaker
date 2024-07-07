using System.Security.Claims;

namespace Ui.Api.Infrastructure.Authentication;

public class HttpContext(IHttpContextAccessor contextAccessor) : IContext
{
    public string? GetClaim(string name)
    {
        return contextAccessor.HttpContext?.User.FindFirstValue(name);
    }
}
