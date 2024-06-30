using Application.Abstractions.Authentication;
using Application.Abstractions.Messaging;
using Application.Maintenances.Responses;
using Application.Maintenances.Services;

namespace Application.Maintenances.Queries.GetMaintenance;

public sealed class GetMaintenanceQueryHandler(
    IIdentityProvider identityProvider,
    MaintenanceFinder maintenanceFinder)
    : IQueryHandler<GetMaintenanceQuery, MaintenanceResponse>
{
    public Task<MaintenanceResponse> Handle(
        GetMaintenanceQuery request,
        CancellationToken cancellationToken = default)
    {
        var maintenance = maintenanceFinder.Find(
            Guid.Parse(request.MaintenanceId),
            identityProvider.GetAuthenticatedUserId());

        return Task.FromResult(new MaintenanceResponse(
            maintenance.Id.ToString(),
            maintenance.VehicleId.ToString(),
            maintenance.Name.Value,
            maintenance.Description?.Value));
    }
}
