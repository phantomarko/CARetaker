using Infrastructure;
using Microsoft.Extensions.Hosting;

namespace Tool.MigrationRunner;

internal class Program
{
    public static void Main(string[] args) => CreateHostBuilder(args).Build().Run();

    public static IHostBuilder CreateHostBuilder(string[] args)
    {
        var builder = Host.CreateDefaultBuilder(args);

        builder.ConfigureServices(services =>
        {
            services.AddPersistence();
        });

        return builder;
    }
}
