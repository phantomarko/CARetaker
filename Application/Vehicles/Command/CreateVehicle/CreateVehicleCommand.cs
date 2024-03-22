using MediatR;

namespace Application.Vehicles.Command.CreateVehicle;

public sealed record CreateVehicleCommand(
    string Name,
    string Plate) : IRequest<Guid>;
