using Application.Vehicles.Commands.CreateVehicle;
using FastEndpoints;
using MediatR;

namespace Ui.Api.Vehicles.Endpoints.CreateVehicle;

public sealed class CreateVehicleEndpoint(ISender sender) : Endpoint<CreateVehicleRequest, CreateVehicleResponse>
{
    public override void Configure()
    {
        Post("api/vehicles");
        AllowAnonymous();
    }

    public override async Task HandleAsync(CreateVehicleRequest request, CancellationToken cancellationToken)
    {
        Guid result = await sender.Send(
            new CreateVehicleCommand(
                request.Name,
                request.Plate), cancellationToken);

        await SendAsync(new CreateVehicleResponse(result), 201, cancellationToken);
    }
}
