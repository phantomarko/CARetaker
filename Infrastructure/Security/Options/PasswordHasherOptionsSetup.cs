using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;

namespace Infrastructure.Security.Options;

public class PasswordHasherOptionsSetup(IConfiguration configuration) : IConfigureOptions<PasswordHasherOptions>
{
    private const string Section = "PasswordHasher";

    public void Configure(PasswordHasherOptions options)
    {
        configuration.GetSection(Section).Bind(options);
    }
}
