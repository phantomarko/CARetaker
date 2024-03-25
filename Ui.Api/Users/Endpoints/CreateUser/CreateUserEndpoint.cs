using Application.Users.Commands.CreateUser;
using FastEndpoints;
using MediatR;

namespace Ui.Api.Users.Endpoints.CreateUser;

public sealed class CreateUserEndpoint(ISender sender) : Endpoint<CreateUserRequest, CreateUserResponse>
{
    public override void Configure()
    {
        Post("api/users");
        AllowAnonymous();
        Description(b => b
            .ClearDefaultProduces(StatusCodes.Status200OK)
            .Produces<CreateUserResponse>(StatusCodes.Status201Created));
    }

    public override async Task HandleAsync(CreateUserRequest request, CancellationToken cancellationToken)
    {
        Guid result = await sender.Send(
            new CreateUserCommand(
                request.Email,
                request.Password), cancellationToken);

        await SendAsync(
            new CreateUserResponse(result),
            StatusCodes.Status201Created,
            cancellationToken);
    }
}
