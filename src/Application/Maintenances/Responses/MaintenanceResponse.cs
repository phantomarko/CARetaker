namespace Application.Maintenances.Responses;

public sealed record MaintenanceResponse(
    string Id,
    string VehicleId,
    string Name,
    string? Description);
