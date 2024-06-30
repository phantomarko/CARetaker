using Application.Maintenances.Commands.CreateMaintenance;
using Application.Maintenances.Queries.GetMaintenance;
using Bogus;

namespace Application.Tests.Fixtures;

public static class MaintenancesMother
{
    private static Faker Faker => new();

    public static CreateMaintenanceCommand MakeCreateMaintenanceCommand(
        string? vehicleId = null,
        string? name = null,
        string? description = null)
    {
        return new CreateMaintenanceCommand(
            vehicleId ?? Guid.NewGuid().ToString(),
            name ?? Faker.Lorem.Word(),
            description);
    }

    public static GetMaintenanceQuery MakeGetMaintenanceQuery(string? id = null)
    {
        return new GetMaintenanceQuery(id ?? Guid.NewGuid().ToString());
    }
}
