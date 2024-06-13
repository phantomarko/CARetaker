using Domain.Maintenances.Exceptions;

namespace Domain.Maintenances;

public sealed record MaintenancePlace
{
    public const int MaximumLength = 100;

    private MaintenancePlace(string value) => Value = value;

    public string Value { get; }

    public static MaintenancePlace Create(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            throw new MaintenancePlaceIsEmptyException();
        }

        if (MaximumLength < value.Length)
        {
            throw new MaintenancePlaceLengthIsInvalidException();
        }

        return new MaintenancePlace(value);
    }
}
