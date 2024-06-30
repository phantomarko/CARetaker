using Application.Users.Commands.CreateUser;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SharedKernel.Responses;

namespace Ui.Api.Controllers.Users.CreateUser;

public class CreateUserController(ISender sender)
    : ApiController
{
    [HttpPost("users")]
    [AllowAnonymous]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<ResourceCreatedResponse>> Index(
        CreateUserRequest request,
        CancellationToken cancellationToken)
    {
        ResourceCreatedResponse result = await sender.Send(
            new CreateUserCommand(
                request.Email,
                request.Password),
            cancellationToken);

        // TODO: set to CreatedAtRoute() pointing to get user controller
        return CreatedAtAction(
            nameof(Index),
            result);
    }
}
