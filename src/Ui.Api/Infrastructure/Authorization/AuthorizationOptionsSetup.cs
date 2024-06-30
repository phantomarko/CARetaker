using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Options;
using Ui.Api.Infrastructure.Authentication;

namespace Ui.Api.Infrastructure.Authorization;

public sealed class AuthorizationOptionsSetup : IConfigureOptions<AuthorizationOptions>
{
    public void Configure(AuthorizationOptions options)
    {
        options.AddPolicy(
            ApplicationPolicies.User,
            x => x.RequireClaim(JwtProvider.IdentityClaim));
    }
}
