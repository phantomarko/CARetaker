using Application.Abstractions;
using Domain.Abstractions;
using Domain.Users;
using Domain.Vehicles;
using Infrastructure.Persistence;
using Infrastructure.Persistence.Options;
using Infrastructure.Persistence.Users;
using Infrastructure.Persistence.Vehicles;
using Infrastructure.Security.Authentication;
using Infrastructure.Security.Authorization;
using Infrastructure.Security.PasswordHasher;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddPersistence(this IServiceCollection services)
    {
        services.ConfigureOptions<DatabaseOptionsSetup>();

        services.AddDbContext<ApplicationDbContext>((serviceProvider, dbContextOptionsBuilder) =>
        {
            DatabaseOptions dbOptions = serviceProvider.GetService<IOptions<DatabaseOptions>>()!.Value;

            dbContextOptionsBuilder.UseSqlServer(
                $"Server={dbOptions.Server},{dbOptions.Port};Database={dbOptions.Name};User Id={dbOptions.User};Password={dbOptions.Password};Encrypt={dbOptions.Encrypt};");

            dbContextOptionsBuilder.EnableDetailedErrors(dbOptions.DetailedErrors);
            dbContextOptionsBuilder.EnableSensitiveDataLogging(dbOptions.SensitiveDataLogging);
        });

        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IVehicleRepository, VehicleRepository>();
        services.AddScoped<IUnitOfWork, UnitOfWork>();

        return services;
    }

    public static IServiceCollection AddSecurity(this IServiceCollection services)
    {
        services.ConfigureOptions<AuthorizationOptionsSetup>();
        services.ConfigureOptions<PasswordHasherOptionsSetup>();
        services.ConfigureOptions<JwtOptionsSetup>();

        services.AddScoped(serviceProvider =>
        {
            PasswordHasherOptions options = serviceProvider.GetService<IOptions<PasswordHasherOptions>>()!.Value;

            return new PasswordHasher(options.Pepper, options.Iterations);
        });

        services.AddScoped<IJwtProvider, JwtProvider>();

        return services;
    }
}
