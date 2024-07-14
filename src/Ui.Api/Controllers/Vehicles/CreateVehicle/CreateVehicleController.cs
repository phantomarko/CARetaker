using Application.Vehicles.Commands.CreateVehicle;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SharedKernel.Responses;
using Ui.Api.Controllers.Vehicles.GetVehicle;
using Ui.Api.Infrastructure.Authorization;

namespace Ui.Api.Controllers.Vehicles.CreateVehicle;

public class CreateVehicleController(ISender sender)
    : ApiController
{
    [HttpPost("vehicles")]
    [Authorize(Policy = ApplicationPolicies.User)]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [ApiExplorerSettings(GroupName = "Vehicles")]
    public async Task<ActionResult<ResourceCreatedResponse>> Index(
        CreateVehicleRequest request,
        CancellationToken cancellationToken)
    {
        var result = await sender.Send(
            new CreateVehicleCommand(
                request.Name,
                request.Plate),
            cancellationToken);

        return CreatedAtRoute(
            nameof(GetVehicleController),
            new { id = result.Id },
            result);
    }
}
