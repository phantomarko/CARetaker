using Domain.Abstractions;
using Domain.Vehicles;
using Infrastructure.Persistence;
using Infrastructure.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<ApplicationContext>(options =>
        {
            // TODO: add options class to automatically map connection strings
            string host = configuration.GetConnectionString("DbHost") ?? "";
            string user = configuration.GetConnectionString("DbUser") ?? "";
            string password = configuration.GetConnectionString("DbPassword") ?? "";
            options.UseSqlServer($"Server={host};Database=caretaker;User Id={user};Password={password};TrustServerCertificate=True;");

            options.EnableDetailedErrors(true);
            options.EnableSensitiveDataLogging(true);
        });

        services.AddScoped<IVehicleRepository, VehicleRepository>();
        services.AddScoped<IUnitOfWork, UnitOfWork>();

        return services;
    }
}
