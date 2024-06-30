namespace Ui.Api.Controllers.Maintenances.CreateMaintenance;

public sealed record CreateMaintenanceRequest(
    string VehicleId,
    string Name,
    string? Description);
