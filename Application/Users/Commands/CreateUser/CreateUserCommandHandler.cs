using Domain.Users;
using MediatR;

namespace Application.Users.Commands.CreateUser;

public sealed class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, Guid>
{
    private readonly PasswordHasher _passwordHasher;
    private readonly IUserRepository _userRepository;

    public CreateUserCommandHandler(PasswordHasher passwordHasher, IUserRepository userRepository)
    {
        _passwordHasher = passwordHasher;
        _userRepository = userRepository;
    }

    public async Task<Guid> Handle(CreateUserCommand request, CancellationToken cancellationToken = default)
    {
        var user = User.Create(
            Guid.NewGuid(),
            Email.Create(request.Email),
            Password.Create(request.Password),
            _passwordHasher);

        await _userRepository.AddAsync(user, cancellationToken);

        return user.Id;
    }
}
