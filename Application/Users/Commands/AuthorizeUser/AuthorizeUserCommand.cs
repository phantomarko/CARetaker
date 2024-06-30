using Application.Abstractions.Messaging;

namespace Application.Users.Commands.AuthorizeUser;

public sealed record AuthorizeUserCommand(string Email, string Password)
    : ICommand<BearerTokenResponse>;
