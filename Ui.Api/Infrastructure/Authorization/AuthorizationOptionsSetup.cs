using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Options;
using System.IdentityModel.Tokens.Jwt;

namespace Ui.Api.Infrastructure.Authorization;

public sealed class AuthorizationOptionsSetup : IConfigureOptions<AuthorizationOptions>
{
    public void Configure(AuthorizationOptions options)
    {
        options.AddPolicy(
            ApplicationPolicies.User,
            x => x.RequireClaim(JwtRegisteredClaimNames.Sub));
    }
}
