using Domain.Users;
using Domain.Users.Exceptions;

namespace Tests.Domain.Unit.Users;

public class PasswordTest
{
    [Theory]
    [InlineData("P4ssw0rd")]
    public void Create_Should_ReturnPassword(string value)
    {
        var password = Password.Create(value);

        Assert.Equal(value, password.Value);
    }

    [Theory]
    [InlineData("")]
    [InlineData("          ")]
    [InlineData("Pass")]
    [InlineData("P4SSW0RD")]
    [InlineData("p4ssw0rd")]
    [InlineData("Password")]
    public void Create_Should_ThrowNotStrongEnoughException(string value)
    {
        Assert.Throws<PasswordIsNotStrongEnoughException>(() => Password.Create(value));
    }
}
