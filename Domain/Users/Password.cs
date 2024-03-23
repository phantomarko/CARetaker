using Domain.Users.Exceptions;

namespace Domain.Users;

public sealed record Password
{
    public const int MinimumLength = 8;

    private Password(string value) => Value = value;

    public string Value { get; init; }

    public static Password Create(string value)
    {
        if (
            string.IsNullOrWhiteSpace(value)
            || value.Length < MinimumLength
            || !value.Any(letter => char.IsLower(letter))
            || !value.Any(letter => char.IsUpper(letter))
            || !value.Any(letter => char.IsNumber(letter)))
        {
            throw new PasswordIsNotStrongEnoughException();
        }

        return new Password(value);
    }
}
