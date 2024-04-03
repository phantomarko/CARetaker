using Domain.Maintenances.Exceptions;

namespace Domain.Maintenances;

public sealed record MaintenanceDescription
{
    public const int MaximumLength = 1000;

    private MaintenanceDescription(string value) => Value = value;

    public string Value { get; init; }

    public static MaintenanceDescription Create(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            throw new MaintenanceDescriptionIsEmptyException();
        }

        if (MaximumLength < value.Length)
        {
            throw new MaintenanceDescriptionLengthIsInvalidException();
        }

        return new MaintenanceDescription(value);
    }
}
