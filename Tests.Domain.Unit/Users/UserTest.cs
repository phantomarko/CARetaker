using Domain.Users;
using Tests.Domain.Fixtures;

namespace Tests.Domain.Unit.Users;

public class UserTest
{
    private readonly PasswordHasher _passwordHasher;

    public UserTest()
    {
        _passwordHasher = UsersMother.MakePasswordHasher();
    }

    [Theory]
    [ClassData(typeof(UserCreateValidData))]
    public void Create_Should_ReturnUser(Guid id, Email email, string password)
    {
        var user = User.Create(id, email, password, _passwordHasher);

        Assert.Equal(user.Id, id);
        Assert.Equal(user.Email, email);
        Assert.True(user.PasswordMatches(password, _passwordHasher));
    }
}

public class UserCreateValidData : TheoryData<Guid, Email, string>
{
    public UserCreateValidData()
    {
        Add(
            Guid.NewGuid(),
            UsersMother.MakeEmail(),
            "$tr0ngP4$$w0rd!");
    }
}
