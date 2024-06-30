using Application.Abstractions.Messaging;
using Domain.Users;
using SharedKernel.Responses;

namespace Application.Users.Commands.CreateUser;

public sealed class CreateUserCommandHandler(
    PasswordHasher passwordHasher,
    IUserRepository userRepository)
    : ICommandHandler<CreateUserCommand, ResourceCreatedResponse>
{
    public async Task<ResourceCreatedResponse> Handle(
        CreateUserCommand request,
        CancellationToken cancellationToken = default)
    {
        var user = User.Create(
            Guid.NewGuid(),
            Email.Create(request.Email),
            Password.Create(request.Password),
            passwordHasher,
            userRepository);

        await userRepository.AddAsync(user, cancellationToken);

        return new ResourceCreatedResponse(user.Id.ToString());
    }
}
