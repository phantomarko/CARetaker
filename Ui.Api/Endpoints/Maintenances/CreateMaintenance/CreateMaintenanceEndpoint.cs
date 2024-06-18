using Application.Maintenances.Commands.CreateMaintenance;
using FastEndpoints;
using MediatR;
using Ui.Api.Infrastructure.Authorization;

namespace Ui.Api.Endpoints.Maintenances.CreateMaintenance;

public sealed class CreateMaintenanceEndpoint(ISender sender)
    : Endpoint<CreateMaintenanceRequest, CreateMaintenanceResponse>
{
    public override void Configure()
    {
        Post("vehicles/{VehicleId}/maintenances");
        Policies(ApplicationPolicies.User);
        Description(b => b
            .ClearDefaultProduces(StatusCodes.Status200OK)
            .Produces<CreateMaintenanceResponse>(StatusCodes.Status201Created));
    }

    public override async Task HandleAsync(
        CreateMaintenanceRequest request,
        CancellationToken cancellationToken)
    {
        var result = await sender.Send(
            new CreateMaintenanceCommand(
                request.VehicleId,
                request.Name,
                request.Description),
            cancellationToken);

        await SendAsync(
            new CreateMaintenanceResponse(result),
            StatusCodes.Status201Created,
            cancellationToken);
    }
}
