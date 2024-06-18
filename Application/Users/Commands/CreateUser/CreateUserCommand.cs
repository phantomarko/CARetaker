using Application.Abstractions.Messaging;

namespace Application.Users.Commands.CreateUser;

public sealed record CreateUserCommand(string Email, string Password)
    : ITransactionalCommand<Guid>;
