using MediatR;

namespace Application.Users.Commands.LoginUser;

public sealed class LoginUserCommandHandler : IRequestHandler<LoginUserCommand, string>
{
    public Task<string> Handle(LoginUserCommand request, CancellationToken cancellationToken)
    {
        return Task.FromResult("fake_token");
    }
}
