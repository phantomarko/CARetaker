using Application.Maintenances.Commands.CreateMaintenance;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SharedKernel.Responses;
using Ui.Api.Controllers.Maintenances.GetMaintenance;
using Ui.Api.Infrastructure.Authorization;

namespace Ui.Api.Controllers.Maintenances.CreateMaintenance;

public class CreateMaintenanceController(ISender sender)
    : ApiController
{
    [HttpPost("maintenances")]
    [Authorize(Policy = ApplicationPolicies.User)]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<ResourceCreatedResponse>> Index(
        CreateMaintenanceRequest request,
        CancellationToken cancellationToken)
    {
        ResourceCreatedResponse result = await sender.Send(
                    new CreateMaintenanceCommand(
                        request.VehicleId,
                        request.Name,
                        request.Description),
                    cancellationToken);

        return CreatedAtRoute(
            nameof(GetMaintenanceController),
            new { id = result.Id },
            result);
    }
}
