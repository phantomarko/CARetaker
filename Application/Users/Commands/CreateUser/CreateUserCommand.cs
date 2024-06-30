using Application.Abstractions.Messaging;
using SharedKernel.Responses;

namespace Application.Users.Commands.CreateUser;

public sealed record CreateUserCommand(string Email, string Password)
    : ITransactionalCommand<ResourceCreatedResponse>;
