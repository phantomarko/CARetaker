using Domain.Users.Exceptions;
using System.Text.RegularExpressions;

namespace Domain.Users;

public sealed record Email
{
    public const int MaximumLength = 150;
    private const string Format = "^[^@\\s]+@[^@\\s]+\\.[^@\\s]+$";

    private Email(string value) => Value = value;

    public string Value { get; init; }

    public static Email Create(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            throw new EmailIsEmptyException();
        }
        
        if (!Regex.IsMatch(value, Format))
        {
            throw new EmailFormatIsInvalidException();
        }

        if (MaximumLength < value.Length)
        {
            throw new EmailLengthIsInvalidException();
        }

        return new Email(value);
    }
}
