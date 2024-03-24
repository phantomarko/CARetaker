using MediatR;

namespace Application.Users.Commands.CreateUser;

public sealed record CreateUserCommand(
    string Email,
    string Password) : IRequest<Guid>;
