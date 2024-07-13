using Application.Maintenances.Queries.GetMaintenance;
using Application.Maintenances.Responses;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Ui.Api.Infrastructure.Authorization;

namespace Ui.Api.Controllers.Maintenances.GetMaintenance;

public class GetMaintenanceController(ISender sender)
    : ApiController
{
    [HttpGet(template: "maintenances/{id}", Name = nameof(GetMaintenanceController))]
    [Authorize(Policy = ApplicationPolicies.User)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [ApiExplorerSettings(GroupName = "Maintenances")]
    public async Task<ActionResult<MaintenanceResponse>> Index(
        string id,
        CancellationToken cancellationToken)
    {
        MaintenanceResponse result = await sender.Send(
            new GetMaintenanceQuery(id),
            cancellationToken);

        return Ok(result);
    }
}
