using Application.Abstractions.Messaging;
using SharedKernel.Responses;

namespace Application.Vehicles.Commands.CreateVehicle;

public sealed record CreateVehicleCommand(string Name, string? Plate)
    : ITransactionalCommand<ResourceCreatedResponse>;
