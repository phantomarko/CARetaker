using Domain.Maintenances.Exceptions;

namespace Domain.Maintenances;

public sealed record Place
{
    public const int MaximumLength = 100;

    private Place(string value) => Value = value;

    public string Value { get; }

    public static Place Create(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            throw new PlaceIsEmptyException();
        }

        if (MaximumLength < value.Length)
        {
            throw new PlaceLengthIsInvalidException();
        }

        return new Place(value);
    }
}
