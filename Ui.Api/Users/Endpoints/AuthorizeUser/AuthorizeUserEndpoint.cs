using Application.Users.Commands.AuthorizeUser;
using FastEndpoints;
using MediatR;

namespace Ui.Api.Users.Endpoints.LoginUser;

public sealed class AuthorizeUserEndpoint(ISender sender) : Endpoint<AuthorizeUserRequest, AuthorizeUserResponse>
{
    public override void Configure()
    {
        Post("users/authorize");
        AllowAnonymous();
    }

    public override async Task HandleAsync(AuthorizeUserRequest request, CancellationToken cancellationToken)
    {
        string token = await sender.Send(
            new AuthorizeUserCommand(
                request.Email,
                request.Password), cancellationToken);

        await SendAsync(
            response: new AuthorizeUserResponse(token),
            cancellation: cancellationToken);
    }
}
