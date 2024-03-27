using Application.Abstractions;
using Application.Users.Commands.AuthorizeUser;
using Application.Users.Exceptions;
using Domain.Users;
using Moq;

namespace Tests.Application.Unit.Users.Commands.AuthorizeUser;

public class AuthorizeUserCommandHandlerTest
{
    private readonly Email _email;
    private readonly Password _password;
    private readonly User _user;
    private readonly Mock<IUserRepository> _userRepository;
    private readonly PasswordHasher _passwordHasher;
    private readonly Mock<IJwtProvider> _jwtProvider;
    private readonly AuthorizeUserCommandHandler _handler;

    public AuthorizeUserCommandHandlerTest()
    {
        _email = Domain.Fixtures.UsersMother.MakeEmail();
        _password = Domain.Fixtures.UsersMother.MakePassword();
        _user = Domain.Fixtures.UsersMother.MakeUser(
            email: _email,
            password: _password,
            passwordHasher: _passwordHasher);

        _userRepository = new Mock<IUserRepository>();
        _passwordHasher = Domain.Fixtures.UsersMother.MakePasswordHasher();
        _jwtProvider = new Mock<IJwtProvider>();
        _handler = new AuthorizeUserCommandHandler(
            _userRepository.Object,
            _passwordHasher,
            _jwtProvider.Object);
    }

    [Fact]
    public async Task Handle_Should_ReturnToken()
    {
        var tokenSource = new CancellationTokenSource();
        var command = Application.Fixtures.UsersMother.MakeAuthorizeUserCommand(
            _email.Value,
            _password.Value);

        _userRepository.Setup(mock => mock.FindByEmailAsync(_email, tokenSource.Token))
            .ReturnsAsync(_user);
        _jwtProvider.Setup(mock => mock.Generate(_user)).Returns("token");

        string token = await _handler.Handle(command, tokenSource.Token);

        _userRepository.VerifyAll();
        Assert.IsType<String>(token);
    }

    [Fact]
    public async Task Handle_Should_ThrowException_WhenUserNotExists()
    {
        var tokenSource = new CancellationTokenSource();
        var command = Application.Fixtures.UsersMother.MakeAuthorizeUserCommand(
            _email.Value,
            _password.Value);

        _userRepository.Setup(mock => mock.FindByEmailAsync(_email, tokenSource.Token));

        await Assert.ThrowsAsync<InvalidCredentialsException>(async () => await _handler.Handle(command, tokenSource.Token));

        _userRepository.VerifyAll();
    }

    [Fact]
    public async Task Handle_Should_ThrowException_WhenPasswordNotMatch()
    {
        var tokenSource = new CancellationTokenSource();
        var command = Application.Fixtures.UsersMother.MakeAuthorizeUserCommand(
            _email.Value,
            "wrongpassword");

        _userRepository.Setup(mock => mock.FindByEmailAsync(_email, tokenSource.Token)).ReturnsAsync(_user);

        await Assert.ThrowsAsync<InvalidCredentialsException>(async () => await _handler.Handle(command, tokenSource.Token));

        _userRepository.VerifyAll();
    }
}
