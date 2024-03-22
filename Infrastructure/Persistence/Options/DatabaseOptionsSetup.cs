using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;

namespace Infrastructure.Persistence.Options;

public class DatabaseOptionsSetup(IConfiguration configuration) : IConfigureOptions<DatabaseOptions>
{
    private const string DatabaseSection = "Database";

    public void Configure(DatabaseOptions options)
    {
        configuration.GetSection(DatabaseSection).Bind(options);
    }
}
