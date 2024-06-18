namespace Ui.Api.Endpoints.Maintenances.CreateMaintenance;

public sealed record CreateMaintenanceRequest(
    string VehicleId,
    string Name,
    string? Description);
