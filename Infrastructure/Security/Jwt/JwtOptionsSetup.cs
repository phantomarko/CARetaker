using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;

namespace Infrastructure.Security.Jwt;

public class JwtOptionsSetup(IConfiguration configuration) : IConfigureOptions<JwtOptions>
{
    private const string Section = "Jwt";

    public void Configure(JwtOptions options)
    {
        configuration.GetSection(Section).Bind(options);
    }
}
