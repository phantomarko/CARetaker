using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;

namespace Infrastructure.Users;

public sealed class PasswordHasherOptionsSetup(IConfiguration configuration)
    : IConfigureOptions<PasswordHasherOptions>
{
    public void Configure(PasswordHasherOptions options)
    {
        configuration.GetSection(PasswordHasherOptions.Section)
            .Bind(options);
    }
}
