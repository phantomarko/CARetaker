using Application.Users.Commands.LoginUser;
using FastEndpoints;
using MediatR;

namespace Ui.Api.Users.Endpoints.LoginUser;

public sealed class LoginUserEndpoint(ISender sender) : Endpoint<LoginUserRequest, LoginUserResponse>
{
    public override void Configure()
    {
        Post("api/users/login");
        AllowAnonymous();
    }

    public override async Task HandleAsync(LoginUserRequest request, CancellationToken cancellationToken)
    {
        string token = await sender.Send(
            new LoginUserCommand(
                request.Email,
                request.Password), cancellationToken);

        await SendAsync(new LoginUserResponse(token), 201, cancellationToken);
    }
}
