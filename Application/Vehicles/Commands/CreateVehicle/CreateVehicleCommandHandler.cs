using Domain.Vehicles;
using MediatR;

namespace Application.Vehicles.Commands.CreateVehicle;

public sealed class CreateVehicleCommandHandler : IRequestHandler<CreateVehicleCommand, Guid>
{
    private readonly IVehicleRepository _vehicleRepository;

    public CreateVehicleCommandHandler(IVehicleRepository vehicleRepository)
    {
        _vehicleRepository = vehicleRepository;
    }

    public async Task<Guid> Handle(CreateVehicleCommand request, CancellationToken cancellationToken = default)
    {
        var vehicle = Vehicle.Create(
            id: Guid.NewGuid(),
            name: VehicleName.Create(request.Name),
            plate: RegistrationPlate.Create(request.Plate));

        await _vehicleRepository.AddAsync(vehicle, cancellationToken);

        return vehicle.Id;
    }
}
