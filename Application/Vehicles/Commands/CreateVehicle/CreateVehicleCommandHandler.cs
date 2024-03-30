using Application.Abstractions;
using Application.Primitives;
using Domain.Vehicles;
using MediatR;

namespace Application.Vehicles.Commands.CreateVehicle;

public sealed class CreateVehicleCommandHandler(IVehicleRepository vehicleRepository, IIdentityProvider identityProvider)
    : AuthenticatedHandler(identityProvider), IRequestHandler<CreateVehicleCommand, Guid>
{
    public async Task<Guid> Handle(CreateVehicleCommand request, CancellationToken cancellationToken = default)
    {
        var vehicle = Vehicle.Create(
            Guid.NewGuid(),
            GetAuthenticatedUserId(),
            RegistrationPlate.Create(request.Plate),
            VehicleName.Create(request.Name));

        await vehicleRepository.AddAsync(vehicle, cancellationToken);

        return vehicle.Id;
    }
}
