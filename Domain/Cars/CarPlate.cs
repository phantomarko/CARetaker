using Domain.Cars.Exception;

namespace Domain.Cars;

public sealed record CarPlate
{
    private CarPlate(string value)
    {
        Value = value;
    }

    public string Value { get; init; }

    public static CarPlate Create(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            throw new InvalidCarPlateException();
        }

        return new CarPlate(value);
    }
}
