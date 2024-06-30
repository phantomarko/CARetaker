using Application.Abstractions.Authentication;
using Application.Abstractions.Messaging;
using Domain.Vehicles;
using SharedKernel.Responses;

namespace Application.Vehicles.Commands.CreateVehicle;

public sealed class CreateVehicleCommandHandler(
    IIdentityProvider identityProvider,
    IVehicleRepository vehicleRepository)
    : ICommandHandler<CreateVehicleCommand, ResourceCreatedResponse>
{
    public async Task<ResourceCreatedResponse> Handle(
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

        return new ResourceCreatedResponse(vehicle.Id.ToString());
    }
}
