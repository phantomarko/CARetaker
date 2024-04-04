using Application.Maintenances.Commands.CreateMaintenance;

namespace Tests.Application.Fixtures;

public static class MaintenancesMother
{
    private const string NameDefault = "Maintenance Name";

    public static CreateMaintenanceCommand MakeCreateMaintenanceCommand(
        string? vehicleId = null,
        string? name = null,
        string? description = null)
    {
        return new CreateMaintenanceCommand(
            vehicleId ?? Guid.NewGuid().ToString(),
            name ?? NameDefault,
            description);
    }
}
