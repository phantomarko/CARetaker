using Domain.Vehicles;
using MediatR;

namespace Application.Vehicles.Command.CreateVehicle;

public sealed class CreateVehicleCommandHandler : IRequestHandler<CreateVehicleCommand, Guid>
{
    private readonly IVehicleRepository _vehicleRepository;

    public CreateVehicleCommandHandler(IVehicleRepository vehicleRepository)
    {
        _vehicleRepository = vehicleRepository;
    }

    public Task<Guid> Handle(CreateVehicleCommand request, CancellationToken cancellationToken = default)
    {
        var vehicle = Vehicle.Create(
            id: Guid.NewGuid(),
            name: VehicleName.Create(request.Name),
            plate: RegistrationPlate.Create(request.Plate));

        _vehicleRepository.Add(vehicle);

        return Task.FromResult(vehicle.Id);
    }
}
