using Application.Abstractions;
using Application.Exceptions;
using Domain.Users;
using MediatR;

namespace Application.Users.Commands.AuthorizeUser;

public sealed class AuthorizeUserCommandHandler(
    IUserRepository userRepository,
    PasswordHasher passwordHasher,
    IJwtProvider jwtProvider)
    : IRequestHandler<AuthorizeUserCommand, string>
{
    public Task<string> Handle(AuthorizeUserCommand request, CancellationToken cancellationToken)
    {
        var email = Email.Create(request.Email);
        User? user = userRepository.FindByEmail(email);

        if (
            user is null
            || !user.PasswordMatches(request.Password, passwordHasher))
        {
            throw new InvalidCredentialsException();
        }

        return Task.FromResult(jwtProvider.Generate(user));
    }
}
