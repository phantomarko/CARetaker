using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Options;
using System.IdentityModel.Tokens.Jwt;

namespace Infrastructure.Security.Authorization;

public class AuthorizationOptionsSetup : IConfigureOptions<AuthorizationOptions>
{
    public void Configure(AuthorizationOptions options)
    {
        options.AddPolicy(
            ApplicationPolicies.User,
            x => x.RequireClaim(JwtRegisteredClaimNames.Sub));
    }
}
