using Domain.Vehicles;
using MediatR;

namespace Application.Vehicles.Commands.CreateVehicle;

public sealed class CreateVehicleCommandHandler(IVehicleRepository vehicleRepository)
    : IRequestHandler<CreateVehicleCommand, Guid>
{
    public async Task<Guid> Handle(CreateVehicleCommand request, CancellationToken cancellationToken = default)
    {
        var vehicle = Vehicle.Create(
            id: Guid.NewGuid(),
            name: VehicleName.Create(request.Name),
            plate: RegistrationPlate.Create(request.Plate));

        await vehicleRepository.AddAsync(vehicle, cancellationToken);

        return vehicle.Id;
    }
}
