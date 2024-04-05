namespace Ui.Api.Maintenances.Endpoints.CreateMaintenance;

public sealed record CreateMaintenanceRequest(
    string VehicleId,
    string Name,
    string? Description);
