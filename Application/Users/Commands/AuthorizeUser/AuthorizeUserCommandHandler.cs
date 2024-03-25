using Application.Abstractions;
using Application.Users.Exceptions;
using Domain.Users;
using MediatR;

namespace Application.Users.Commands.AuthorizeUser;

public sealed class AuthorizeUserCommandHandler(IUserRepository userRepository, PasswordHasher passwordHasher, IJwtProvider jwtProvider)
    : IRequestHandler<AuthorizeUserCommand, string>
{
    public async Task<string> Handle(AuthorizeUserCommand request, CancellationToken cancellationToken)
    {
        var email = Email.Create(request.Email);
        User? user = await userRepository.FindByEmailAsync(email, cancellationToken);

        if (
            user is null
            || !user.PasswordMatches(request.Password, passwordHasher))
        {
            throw new InvalidCredentialsException();
        }

        return jwtProvider.Generate(user);
    }
}
