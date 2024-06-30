using Application.Abstractions.Messaging;
using Application.Users.Responses;

namespace Application.Users.Commands.AuthorizeUser;

public sealed record AuthorizeUserCommand(string Email, string Password)
    : ICommand<BearerTokenResponse>;
