using MediatR;

namespace Application.Vehicles.Command.CreateCar;

public sealed record CreateCarCommand(
    string Name,
    string Plate) : IRequest<Guid>;
