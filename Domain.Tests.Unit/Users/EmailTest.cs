using Domain.Users;
using Domain.Users.Exceptions;

namespace Domain.Tests.Unit.Users;

public class EmailTest
{
    [Theory]
    [ClassData(typeof(EmailCreateValidData))]
    public void Create_Should_ReturnEmail(string value)
    {
        var email = Email.Create(value);

        Assert.Equal(value, email.Value);
    }

    [Theory]
    [ClassData(typeof(EmailCreateInvalidData))]
    public void Create_Should_ThrowException(Type expectedException, string value)
    {
        Assert.Throws(expectedException, () => Email.Create(value));
    }
}

public class EmailCreateValidData : TheoryData<string>
{
    public EmailCreateValidData()
    {
        string emailDomain = "@domain.example";
        int maximumLength = Email.MaximumLength - emailDomain.Length;

        Add("email" + emailDomain);
        Add(new string('x', maximumLength - 1) + emailDomain);
        Add(new string('x', maximumLength) + emailDomain);
    }
}

public class EmailCreateInvalidData : TheoryData<Type, string>
{
    public EmailCreateInvalidData()
    {
        string emailDomain = "@domain.example";
        int maximumLength = Email.MaximumLength - emailDomain.Length;

        Add(
            typeof(EmailIsEmptyException),
            "");
        Add(
            typeof(EmailIsEmptyException),
            "     ");
        Add(
            typeof(EmailFormatIsInvalidException),
            "invalid@domain");
        Add(
            typeof(EmailFormatIsInvalidException),
            "invalid@.example");
        Add(
            typeof(EmailFormatIsInvalidException),
            "@domain.example");
        Add(
            typeof(EmailLengthIsInvalidException),
            new string('x', maximumLength + 1) + emailDomain);
    }
}
