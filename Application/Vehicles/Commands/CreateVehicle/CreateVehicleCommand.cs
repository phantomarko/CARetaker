using Application.Abstractions.Messaging;

namespace Application.Vehicles.Commands.CreateVehicle;

public sealed record CreateVehicleCommand(string Name, string? Plate)
    : ITransactionalCommand<Guid>;
