using MediatR;

namespace Application.Maintenances.Commands.CreateMaintenance;

public sealed record CreateMaintenanceCommand(
    string VehicleId,
    string Name,
    string? Description
    ) : IRequest<Guid>;
