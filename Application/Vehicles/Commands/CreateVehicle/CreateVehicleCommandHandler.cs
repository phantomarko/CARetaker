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
            Name.Create(request.Name),
            request.Plate is null 
                ? null 
                : RegistrationPlate.Create(request.Plate),
            vehicleRepository);

        await vehicleRepository.AddAsync(vehicle, cancellationToken);

        return vehicle.Id;
    }
}
