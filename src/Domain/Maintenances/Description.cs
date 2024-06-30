using Domain.Maintenances.Exceptions;

namespace Domain.Maintenances;

public sealed record Description
{
    public const int MaximumLength = 1000;

    private Description(string value) => Value = value;

    public string Value { get; init; }

    public static Description Create(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            throw new DescriptionIsEmptyException();
        }

        if (MaximumLength < value.Length)
        {
            throw new DescriptionLengthIsInvalidException();
        }

        return new Description(value);
    }
}
