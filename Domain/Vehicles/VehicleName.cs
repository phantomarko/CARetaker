using Domain.Vehicles.Exception;

namespace Domain.Vehicles;

public sealed record VehicleName
{
    public const int MaximumLength = 30;

    private VehicleName(string value) => Value = value;

    public string Value { get; init; }

    public static VehicleName Create(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            throw new VehicleNameIsEmptyException();
        }
        if (MaximumLength < value.Length)
        {
            throw new VehicleNameLengthIsInvalidException();
        }

        return new VehicleName(value);
    }
}
