using Application.Abstractions.Messaging;
using SharedKernel.Responses;

namespace Application.Maintenances.Commands.CreateMaintenance;

public sealed record CreateMaintenanceCommand(
    string VehicleId,
    string Name,
    string? Description
    ) : ITransactionalCommand<ResourceCreatedResponse>;
