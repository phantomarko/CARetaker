using Domain.Users;

namespace Tests.Domain.Fixtures;

public static class UsersMother
{
    private const string EmailDefault = "some.user@domain.example";

    public static Email MakeEmail(string? value = null)
    {
        return Email.Create(value ?? EmailDefault);
    }
}
