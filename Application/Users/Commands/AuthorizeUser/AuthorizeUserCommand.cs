using MediatR;

namespace Application.Users.Commands.AuthorizeUser;

public sealed record AuthorizeUserCommand(string Email, string Password)
    : IRequest<string>;
