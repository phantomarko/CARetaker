using Application.Abstractions.Authentication;
using Application.Users.Commands.AuthorizeUser;
using Application.Users.Exceptions;
using Application.Users.Responses;
using Domain.Users;
using Moq;

namespace Application.Tests.Unit.Users.Commands.AuthorizeUser;

public class AuthorizeUserCommandHandlerTest
{
    private readonly Email _email;
    private readonly Password _password;
    private readonly User _user;
    private readonly Mock<IUserRepository> _userRepository;
    private readonly Mock<IJwtProvider> _jwtProvider;
    private readonly AuthorizeUserCommandHandler _handler;

    public AuthorizeUserCommandHandlerTest()
    {
        var passwordHasher = Domain.Tests.Fixtures.UsersMother.MakePasswordHasher();

        _email = Domain.Tests.Fixtures.UsersMother.MakeEmail();
        _password = Domain.Tests.Fixtures.UsersMother.MakePassword();
        _user = Domain.Tests.Fixtures.UsersMother.MakeUser(
            email: _email,
            password: _password,
            passwordHasher: passwordHasher);

        _userRepository = new Mock<IUserRepository>();
        _jwtProvider = new Mock<IJwtProvider>();
        _handler = new AuthorizeUserCommandHandler(
            _userRepository.Object,
            passwordHasher,
            _jwtProvider.Object);
    }

    [Fact]
    public async Task Handle_Should_ReturnToken()
    {
        var command = MakeCommand();
        var jwtValue = "token";
        UserExistsWithTheGivenEmail();
        _jwtProvider.Setup(mock => mock.Generate(_user)).Returns(jwtValue);

        var result = await _handler.Handle(command);

        Assert.IsType<BearerTokenResponse>(result);
        Assert.Equal(jwtValue, result.BearerToken);
        _userRepository.VerifyAll();
        _jwtProvider.VerifyAll();
    }

    [Fact]
    public async Task Handle_Should_ThrowException_WhenUserNotExists()
    {
        var command = MakeCommand();
        UserNotExistsWithTheGivenEmail();

        await Assert.ThrowsAsync<InvalidCredentialsException>(async () =>
            await _handler.Handle(command));

        _userRepository.VerifyAll();
    }

    [Fact]
    public async Task Handle_Should_ThrowException_WhenPasswordNotMatch()
    {
        var command = MakeCommand("wrongpassword");
        UserExistsWithTheGivenEmail();

        await Assert.ThrowsAsync<InvalidCredentialsException>(async () =>
            await _handler.Handle(command));

        _userRepository.VerifyAll();
    }

    private AuthorizeUserCommand MakeCommand(string? password = null)
    {
        return Fixtures.UsersMother.MakeAuthorizeUserCommand(
            _email.Value,
            password ?? _password.Value);
    }

    private void UserExistsWithTheGivenEmail()
    {
        _userRepository.Setup(mock => mock.FindByEmail(_email))
            .Returns(_user);
    }

    private void UserNotExistsWithTheGivenEmail()
    {
        _userRepository.Setup(mock => mock.FindByEmail(_email));
    }
}
