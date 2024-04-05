using Application.Abstractions;
using Application.Primitives;
using Domain.Vehicles;
using MediatR;

namespace Application.Vehicles.Commands.CreateVehicle;

public sealed class CreateVehicleCommandHandler(
    IIdentityProvider identityProvider,
    IVehicleRepository vehicleRepository) 
    : AuthenticatedHandler(identityProvider), IRequestHandler<CreateVehicleCommand, Guid>
{
    public async Task<Guid> Handle(
        CreateVehicleCommand request,
        CancellationToken cancellationToken = default)
    {
        var vehicle = Vehicle.Create(
            Guid.NewGuid(),
            AuthenticatedUserId,
            RegistrationPlate.Create(request.Plate),
            VehicleName.Create(request.Name),
            vehicleRepository);

        await vehicleRepository.AddAsync(vehicle, cancellationToken);

        return vehicle.Id;
    }
}
