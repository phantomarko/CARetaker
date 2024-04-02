using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;

namespace Infrastructure.Persistence;

public class DatabaseOptionsSetup(IConfiguration configuration) : IConfigureOptions<DatabaseOptions>
{
    public void Configure(DatabaseOptions options)
    {
        configuration.GetSection(DatabaseOptions.Section).Bind(options);
    }
}
