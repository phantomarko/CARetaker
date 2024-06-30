using Application.Abstractions.Authentication;
using Application.Abstractions.Messaging;
using Application.Maintenances.Services;
using Domain.Maintenances;
using SharedKernel.Responses;

namespace Application.Maintenances.Commands.CreateMaintenance;

public sealed class CreateMaintenanceCommandHandler(
    IIdentityProvider identityProvider,
    IMaintenanceRepository maintenanceRepository,
    VehicleFinder vehicleFinder)
    : ICommandHandler<CreateMaintenanceCommand, ResourceCreatedResponse>
{
    public async Task<ResourceCreatedResponse> Handle(
        CreateMaintenanceCommand request,
        CancellationToken cancellationToken = default)
    {
        var vehicleId = new Guid(request.VehicleId);
        var userId = identityProvider.GetAuthenticatedUserId();

        vehicleFinder.GuardAgainstNotExistingVehicle(vehicleId, userId);

        var maintenance = Maintenance.Create(
            Guid.NewGuid(),
            userId,
            vehicleId,
            Name.Create(request.Name),
            request.Description is null
                ? null
                : Description.Create(request.Description));

        await maintenanceRepository.AddAsync(maintenance, cancellationToken);

        return new ResourceCreatedResponse(maintenance.Id.ToString());
    }
}
