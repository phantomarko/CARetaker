using Domain.Users;
using Tests.Domain.Fixtures;

namespace Tests.Domain.Unit.Users;

public class UserTest
{
    [Theory]
    [ClassData(typeof(UserCreateValidData))]
    public void Create_Should_ReturnUser(Guid id, Email email)
    {
        var user = User.Create(id, email);

        Assert.Equal(user.Id, id);
        Assert.Equal(user.Email, email);
    }
}

public class UserCreateValidData : TheoryData<Guid, Email>
{
    public UserCreateValidData()
    {
        Add(
            Guid.NewGuid(),
            UsersMother.MakeEmail());
    }
}
