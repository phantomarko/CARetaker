using Domain.Users;
using Domain.Users.Exceptions;
using Moq;
using Tests.Domain.Fixtures;

namespace Tests.Domain.Unit.Users;

public class UserTest
{
    private readonly Guid _id;
    private readonly Email _email;
    private readonly Password _password;
    private readonly PasswordHasher _passwordHasher;
    private readonly Mock<IUserRepository> _userRepository;

    public UserTest()
    {
        _id = Guid.NewGuid();
        _email = UsersMother.MakeEmail();
        _password = UsersMother.MakePassword();
        _passwordHasher = UsersMother.MakePasswordHasher();
        _userRepository = new Mock<IUserRepository>();
    }

    [Fact]
    public void Create_Should_ReturnUser()
    {
        _userRepository.Setup(mock => mock.FindByEmail(_email));

        var user = User.Create(
            _id,
            _email,
            _password,
            _passwordHasher,
            _userRepository.Object);

        Assert.Equal(_id, user.Id);
        Assert.Equal(_email, user.Email);
        Assert.True(user.PasswordMatches(_password.Value, _passwordHasher));
        _userRepository.VerifyAll();
    }

    [Fact]
    public void Create_Should_ThrowException_WhenEmailIsUsed()
    {
        _userRepository.Setup(mock => mock.FindByEmail(_email))
            .Returns(UsersMother.MakeUser());

        Assert.Throws<EmailIsAlreadyInUseException>(() => User.Create(
            _id,
            _email,
            _password,
            _passwordHasher,
            _userRepository.Object));

        _userRepository.VerifyAll();
    }
}
