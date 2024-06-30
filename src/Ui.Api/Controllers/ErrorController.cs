using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using SharedKernel.Exceptions;

namespace Ui.Api.Controllers;

[ApiExplorerSettings(IgnoreApi = true)]
public class ErrorController : ApiController
{
    [Route("/error")]
    public IActionResult HandleError()
    {
        var handler = HttpContext.Features.Get<IExceptionHandlerFeature>()!;

        if (handler.Error is NotFoundException)
        {
            return NotFound();
        }
        
        if (handler.Error is UnauthorizedException)
        {
            return Unauthorized();
        }

        return Problem(title: handler.Error.Message);
    }
}
