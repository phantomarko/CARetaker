using Domain.Maintenances.Exceptions;

namespace Domain.Maintenances;

public sealed record MaintenanceName
{
    public const int MaximumLength = 100;

    public MaintenanceName(string value) => Value = value;

    public string Value { get; init; }

    public static MaintenanceName Create(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            throw new MaintenanceNameIsEmptyException();
        }

        if (MaximumLength < value.Length)
        {
            throw new MaintenanceNameLengthIsInvalidException();
        }

        return new MaintenanceName(value);
    }
}
