using Application.Abstractions;
using Application.Abstractions.Messaging;
using Domain.Vehicles;

namespace Application.Vehicles.Commands.CreateVehicle;

public sealed class CreateVehicleCommandHandler(
    IIdentityProvider identityProvider,
    IVehicleRepository vehicleRepository) 
    : ICommandHandler<CreateVehicleCommand, Guid>
{
    public async Task<Guid> Handle(
        CreateVehicleCommand request,
        CancellationToken cancellationToken = default)
    {
        var vehicle = Vehicle.Create(
            Guid.NewGuid(),
            identityProvider.GetAuthenticatedUserId(),
            RegistrationPlate.Create(request.Plate),
            VehicleName.Create(request.Name),
            vehicleRepository);

        await vehicleRepository.AddAsync(vehicle, cancellationToken);

        return vehicle.Id;
    }
}
