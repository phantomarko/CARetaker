using Application.Vehicles.Queries.GetVehicle;
using Application.Vehicles.Responses;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Ui.Api.Infrastructure.Authorization;

namespace Ui.Api.Controllers.Vehicles.GetVehicle;

public class GetVehicleController(ISender sender)
    : ApiController
{
    [HttpGet(template: "vehicles/{id}", Name = nameof(GetVehicleController))]
    [Authorize(Policy = ApplicationPolicies.User)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [ApiExplorerSettings(GroupName = "Vehicles")]
    public async Task<ActionResult<VehicleResponse>> Index(
        string id,
        CancellationToken cancellationToken)
    {
        VehicleResponse result = await sender.Send(
            new GetVehicleQuery(id),
            cancellationToken);

        return Ok(result);
    }
}
