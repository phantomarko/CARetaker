namespace Application.Maintenances.Queries.GetMaintenance;

public sealed record GetMaintenanceQueryResponse(
    string Id,
    string VehicleId,
    string Name,
    string? Description);
