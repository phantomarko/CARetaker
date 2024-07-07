using Application.Abstractions.Data;
using Application.Maintenances.Services;
using Domain.Maintenances;
using Domain.Users;
using Domain.Vehicles;
using Infrastructure.Maintenances;
using Infrastructure.Persistence;
using Infrastructure.Persistence.Maintenances;
using Infrastructure.Persistence.Users;
using Infrastructure.Persistence.Vehicles;
using Infrastructure.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        services.AddPersistence();

        // Users
        services.ConfigureOptions<PasswordHasherOptionsSetup>();
        services.AddScoped(serviceProvider =>
        {
            PasswordHasherOptions options = serviceProvider.GetService<IOptions<PasswordHasherOptions>>()!.Value;

            return new PasswordHasher(options.Pepper, options.Iterations);
        });

        // Maintenances
        services.AddScoped<IVehicleClient, VehicleRepositoryClient>();

        return services;
    }

    public static IServiceCollection AddPersistence(this IServiceCollection services)
    {
        services.ConfigureOptions<DatabaseOptionsSetup>();

        services.AddDbContext<ApplicationDbContext>((serviceProvider, dbContextOptionsBuilder) =>
        {
            DatabaseOptions dbOptions = serviceProvider.GetService<IOptions<DatabaseOptions>>()!.Value;

            dbContextOptionsBuilder.UseNpgsql(
                $"Server={dbOptions.Server};Port={dbOptions.Port};Database={dbOptions.Name};User Id={dbOptions.User};Password={dbOptions.Password};");

            dbContextOptionsBuilder.EnableDetailedErrors(dbOptions.DetailedErrors);
            dbContextOptionsBuilder.EnableSensitiveDataLogging(dbOptions.SensitiveDataLogging);
        });

        services.AddScoped<IMaintenanceRepository, MaintenanceRepository>();
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IVehicleRepository, VehicleRepository>();
        services.AddScoped<IUnitOfWork, UnitOfWork>();

        return services;
    }
}
