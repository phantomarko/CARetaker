using MediatR;

namespace Application.Vehicles.Commands.CreateVehicle;

public sealed record CreateVehicleCommand(string Name, string Plate)
    : IRequest<Guid>;
