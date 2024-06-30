using Microsoft.Extensions.Options;

namespace Ui.Api.Infrastructure.Authentication;

public sealed class JwtOptionsSetup(IConfiguration configuration)
    : IConfigureOptions<JwtOptions>
{
    public void Configure(JwtOptions options)
    {
        configuration.GetSection(JwtOptions.Section)
            .Bind(options);
    }
}
