using Application.Users.Queries.GetAuthenticatedUser;
using Application.Users.Responses;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Ui.Api.Infrastructure.Authorization;

namespace Ui.Api.Controllers.Users.GetAuthenticatedUser;

public sealed class GetAuthenticatedUserController(ISender sender)
    : ApiController
{
    [HttpGet(template: "users/me", Name = nameof(GetAuthenticatedUserController))]
    [Authorize(Policy = ApplicationPolicies.User)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [ApiExplorerSettings(GroupName = "Users")]
    public async Task<ActionResult<UserResponse>> Index(
        CancellationToken cancellationToken)
    {
        UserResponse result = await sender.Send(
            new GetAuthenticatedUserQuery(),
            cancellationToken);

        return Ok(result);
    }
}
