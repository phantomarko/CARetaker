using Application.Abstractions;
using Application.Exceptions;
using Application.Primitives;
using Domain.Maintenances;
using Domain.Maintenances.Proxies;
using MediatR;

namespace Application.Maintenances.Commands.CreateMaintenance;

public sealed class CreateMaintenanceCommandHandler(
    IIdentityProvider identityProvider,
    IMaintenanceRepository maintenanceRepository,
    VehicleRepositoryProxy vehicleRepository)
    : AuthenticatedHandler(identityProvider), IRequestHandler<CreateMaintenanceCommand, Guid>
{
    public async Task<Guid> Handle(
        CreateMaintenanceCommand request,
        CancellationToken cancellationToken = default)
    {
        var userId = AuthenticatedUserId;
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

        return maintenance.Id;
    }

    private void GuardAgainstNotExistingVehicle(Guid userId, Guid vehicleId)
    {
        if (vehicleRepository.FindByUserAndId(userId, vehicleId) is null)
        {
            throw new VehicleNotFoundException(vehicleId.ToString());
        }
    }
}
