using Domain.Users;
using Moq;

namespace Tests.Domain.Fixtures;

public static class UsersMother
{
    private const string EmailDefault = "some.user@domain.example";
    private const string PasswordDefault = "P4ssw0rd";
    private const string PasswordHasherPepperDefault = "P3pp3r";
    private const int PasswordHasherIterationsDefault = 2;

    public static User MakeUser(
        Guid? id = null,
        Email? email = null,
        Password? password = null,
        PasswordHasher? passwordHasher = null)
    {
        return User.Create(
            id ?? Guid.NewGuid(),
            email ?? MakeEmail(),
            password ?? MakePassword(),
            passwordHasher ?? MakePasswordHasher(),
            new Mock<IUserRepository>().Object);
    }

    public static Email MakeEmail(string? value = null)
    {
        return Email.Create(value ?? EmailDefault);
    }

    public static Password MakePassword(string? value = null)
    {
        return Password.Create(value ?? PasswordDefault);
    }

    public static PasswordHasher MakePasswordHasher(string? pepper = null, int? iterations = null)
    {
        return new PasswordHasher(
            pepper ?? PasswordHasherPepperDefault,
            iterations ?? PasswordHasherIterationsDefault);
    }
}
