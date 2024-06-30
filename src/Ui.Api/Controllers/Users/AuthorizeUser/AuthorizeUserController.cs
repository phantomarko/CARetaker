using Application.Users.Commands.AuthorizeUser;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Ui.Api.Controllers.Users.AuthorizeUser;

public class AuthorizeUserController(ISender sender)
    : ApiController
{
    [HttpPost("users/authorize")]
    [AllowAnonymous]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<BearerTokenResponse>> Index(
        AuthorizeUserRequest request,
        CancellationToken cancellationToken)
    {
        BearerTokenResponse result = await sender.Send(
            new AuthorizeUserCommand(
                request.Email,
                request.Password),
            cancellationToken);

        return base.Ok(result);
    }
}
