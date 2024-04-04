using Application.Abstractions;
using Application.Primitives;
using Domain.Maintenances;
using MediatR;

namespace Application.Maintenances.Commands.CreateMaintenance;

public sealed class CreateMaintenanceCommandHandler(
    IIdentityProvider identityProvider,
    IMaintenanceRepository maintenanceRepository)
    : AuthenticatedHandler(identityProvider),
    IRequestHandler<CreateMaintenanceCommand, Guid>
{
    public async Task<Guid> Handle(CreateMaintenanceCommand request, CancellationToken cancellationToken = default)
    {
        var maintenance = Maintenance.Create(
            Guid.NewGuid(),
            GetAuthenticatedUserId(),
            new Guid(request.VehicleId),
            MaintenanceName.Create(request.Name),
            request.Description is null
                ? null
                : MaintenanceDescription.Create(request.Description));

        await maintenanceRepository.AddAsync(maintenance, cancellationToken);

        return maintenance.Id;
    }
}
