using Application.Abstractions.Authentication;
using Application.Abstractions.Messaging;
using Application.Exceptions;
using Domain.Maintenances;
using Domain.Maintenances.Proxies;
using SharedKernel.Responses;

namespace Application.Maintenances.Commands.CreateMaintenance;

public sealed class CreateMaintenanceCommandHandler(
    IIdentityProvider identityProvider,
    IMaintenanceRepository maintenanceRepository,
    VehicleRepositoryProxy vehicleRepository)
    : ICommandHandler<CreateMaintenanceCommand, ResourceCreatedResponse>
{
    public async Task<ResourceCreatedResponse> Handle(
        CreateMaintenanceCommand request,
        CancellationToken cancellationToken = default)
    {
        var userId = identityProvider.GetAuthenticatedUserId();
        var vehicleId = new Guid(request.VehicleId);

        GuardAgainstNotExistingVehicle(userId, vehicleId);

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

    private void GuardAgainstNotExistingVehicle(Guid userId, Guid vehicleId)
    {
        var vehicle = vehicleRepository.FindById(vehicleId);
        if (
            vehicle is null
            || !vehicle.UserId.Equals(userId))
        {
            throw new VehicleNotFoundException(vehicleId.ToString());
        }
    }
}
