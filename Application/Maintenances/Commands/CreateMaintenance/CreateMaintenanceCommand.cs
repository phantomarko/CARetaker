using Application.Abstractions.Messaging;

namespace Application.Maintenances.Commands.CreateMaintenance;

public sealed record CreateMaintenanceCommand(
    string VehicleId,
    string Name,
    string? Description
    ) : ITransactionalCommand<Guid>;
