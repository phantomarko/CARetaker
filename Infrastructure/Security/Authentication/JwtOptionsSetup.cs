using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;

namespace Infrastructure.Security.Authentication;

public class JwtOptionsSetup(IConfiguration configuration) : IConfigureOptions<JwtOptions>
{
    public void Configure(JwtOptions options)
    {
        configuration.GetSection(JwtOptions.Section).Bind(options);
    }
}
