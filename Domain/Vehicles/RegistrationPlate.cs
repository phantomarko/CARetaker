using Domain.Vehicles.Exceptions;

namespace Domain.Vehicles;

public sealed record RegistrationPlate
{
    public const int MaximumLength = 18;

    private RegistrationPlate(string value) => Value = value;

    public string Value { get; init; }

    public static RegistrationPlate Create(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            throw new RegistrationPlateIsEmptyException();
        }

        if (MaximumLength < value.Length)
        {
            throw new RegistrationPlateLengthIsInvalidException();
        }

        if (
            (value.Length == 1 && value == "-")
            || value.Any(character => !char.IsLetterOrDigit(character) && character != '-'))
        {
            throw new RegistrationPlateFormatIsInvalidException();
        }

        return new RegistrationPlate(value.ToUpper());
    }
}
