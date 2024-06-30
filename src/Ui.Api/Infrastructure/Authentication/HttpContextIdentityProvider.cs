using Application.Abstractions.Authentication;
using SharedKernel.Exceptions;
using System.Security.Claims;

namespace Ui.Api.Infrastructure.Authentication;

public sealed class HttpContextIdentityProvider(IHttpContextAccessor context)
    : IIdentityProvider
{
    public Guid GetAuthenticatedUserId()
    {
        var id = GetClaimFromContext(JwtProvider.IdentityClaim);

        return id is null ? throw new UnauthorizedException() : Guid.Parse(id);
    }

    private string? GetClaimFromContext(string claim)
    {
        return context.HttpContext?.User.FindFirstValue(claim);
    }
}
