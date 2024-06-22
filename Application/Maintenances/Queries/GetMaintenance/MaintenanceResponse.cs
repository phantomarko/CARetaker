namespace Application.Maintenances.Queries.GetMaintenance;

public sealed record MaintenanceResponse(
    string Id,
    string VehicleId,
    string Name,
    string? Description);
