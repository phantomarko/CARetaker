using Application.Abstractions;
using Application.Abstractions.Messaging;
using Application.Exceptions;
using Domain.Maintenances;

namespace Application.Maintenances.Queries.GetMaintenance;

public sealed class GetMaintenanceQueryHandler(
    IIdentityProvider identityProvider,
    IMaintenanceRepository maintenanceRepository)
    : IQueryHandler<GetMaintenanceQuery, MaintenanceResponse>
{
    public Task<MaintenanceResponse> Handle(GetMaintenanceQuery request, CancellationToken cancellationToken)
    {
        var maintenance = GetMaintenance(request.MaintenanceId);

        return Task.FromResult(new MaintenanceResponse(
            maintenance.Id.ToString(),
            maintenance.VehicleId.ToString(),
            maintenance.Name.Value,
            maintenance.Description?.Value));
    }

    private Maintenance GetMaintenance(string maintenanceId)
    {
        var maintenance = maintenanceRepository.GetById(new Guid(maintenanceId));
        if (
            maintenance is null 
            || !maintenance.UserId.Equals(identityProvider.GetAuthenticatedUserId()))
        {
            throw new MaintenanceNotFoundException(maintenanceId);
        }

        return maintenance;
    }
}
