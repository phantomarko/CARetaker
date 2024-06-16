using Application.Maintenances.Queries.GetMaintenance;
using FastEndpoints;
using Infrastructure.Security.Authorization;
using MediatR;

namespace Ui.Api.Maintenances.Endpoints.GetMaintenance;

public sealed class GetMaintenanceEndpoint(ISender sender)
    : Endpoint<GetMaintenanceRequest, GetMaintenanceQueryResponse>
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
        GetMaintenanceQueryResponse result = await sender.Send(
            new GetMaintenanceQuery(request.MaintenanceId),
            cancellationToken);

        await SendAsync(
            result,
            cancellation: cancellationToken);
    }
}
