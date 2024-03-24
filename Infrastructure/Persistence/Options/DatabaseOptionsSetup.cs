using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;

namespace Infrastructure.Persistence.Options;

public class DatabaseOptionsSetup(IConfiguration configuration) : IConfigureOptions<DatabaseOptions>
{
    private const string Section = "Database";

    public void Configure(DatabaseOptions options)
    {
        configuration.GetSection(Section).Bind(options);
    }
}
