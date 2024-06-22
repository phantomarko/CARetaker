using Application.Maintenances.Queries.GetMaintenance;
using FastEndpoints;
using MediatR;
using Ui.Api.Infrastructure.Authorization;

namespace Ui.Api.Maintenances.Endpoints.GetMaintenance;

public sealed class GetMaintenanceEndpoint(ISender sender)
    : Endpoint<GetMaintenanceRequest, MaintenanceResponse>
{
    public override void Configure()
    {
        Get("maintenances/{MaintenanceId}/");
        Policies(ApplicationPolicies.User);
    }

    public override async Task HandleAsync(
        GetMaintenanceRequest request,
        CancellationToken cancellationToken)
    {
        MaintenanceResponse maintenance = await sender.Send(
            new GetMaintenanceQuery(request.MaintenanceId),
            cancellationToken);

        await SendAsync(
            maintenance,
            cancellation: cancellationToken);
    }
}
