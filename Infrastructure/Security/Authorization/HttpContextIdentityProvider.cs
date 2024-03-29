using Application.Abstractions;
using Microsoft.AspNetCore.Http;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace Infrastructure.Security.Authorization;

public class HttpContextIdentityProvider(IHttpContextAccessor context) : IIdentityProvider
{
    public Guid? GetAuthenticatedUserId()
    {
        var id = GetClaimFromContext(JwtRegisteredClaimNames.Sub);

        return id is null ? null : new Guid(id);
    }

    private string? GetClaimFromContext(string claim)
    {
        return context.HttpContext?.User.FindFirstValue(claim);
    }
}
