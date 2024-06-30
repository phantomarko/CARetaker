using Domain.Maintenances.Exceptions;

namespace Domain.Maintenances;

public sealed record Name
{
    public const int MaximumLength = 100;

    private Name(string value) => Value = value;

    public string Value { get; init; }

    public static Name Create(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            throw new NameIsEmptyException();
        }

        if (MaximumLength < value.Length)
        {
            throw new NameLengthIsInvalidException();
        }

        return new Name(value);
    }
}
