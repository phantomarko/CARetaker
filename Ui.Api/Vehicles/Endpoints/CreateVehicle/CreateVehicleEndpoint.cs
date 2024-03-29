using Application.Vehicles.Commands.CreateVehicle;
using FastEndpoints;
using Infrastructure.Security.Authorization;
using MediatR;
using Ui.Api.Users.Endpoints.CreateUser;

namespace Ui.Api.Vehicles.Endpoints.CreateVehicle;

public sealed class CreateVehicleEndpoint(ISender sender) : Endpoint<CreateVehicleRequest, CreateVehicleResponse>
{
    public override void Configure()
    {
        Post("api/vehicles");
        Policies(ApplicationPolicies.User);
        Description(b => b
            .ClearDefaultProduces(StatusCodes.Status200OK)
            .Produces<CreateUserResponse>(StatusCodes.Status201Created));
    }

    public override async Task HandleAsync(CreateVehicleRequest request, CancellationToken cancellationToken)
    {
        Guid result = await sender.Send(
            new CreateVehicleCommand(
                request.Name,
                request.Plate), cancellationToken);

        await SendAsync(
            new CreateVehicleResponse(result),
            StatusCodes.Status201Created,
            cancellationToken);
    }
}
