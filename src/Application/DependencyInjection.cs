﻿using Application.Behaviours;
using Application.Maintenances.Services;
using Application.Vehicles.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddMediatR(configuration =>
        {
            configuration.RegisterServicesFromAssembly(typeof(DependencyInjection).Assembly);

            configuration.AddOpenBehavior(typeof(TransactionalPipelineBehaviour<,>));
        });

        // Vehicles
        services.AddTransient<VehicleFinder>();

        // Maintenances
        services.AddTransient<MaintenanceFinder>();
        services.AddTransient<VehicleFacade>();

        return services;
    }
}
