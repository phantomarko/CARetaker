using Application.Abstractions.Authentication;
using System.Security.Claims;

namespace Ui.Api.Infrastructure.Authentication;

public sealed class HttpContextIdentityProvider(IHttpContextAccessor context)
    : IIdentityProvider
{
    public Guid GetAuthenticatedUserId()
    {
        var id = GetClaimFromContext(JwtProvider.IdentityClaim);

        return id is null ? throw new Exception("User not available") : new Guid(id);
    }

    private string? GetClaimFromContext(string claim)
    {
        return context.HttpContext?.User.FindFirstValue(claim);
    }
}
