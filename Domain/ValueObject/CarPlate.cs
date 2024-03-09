namespace Domain.ValueObject;

public class CarPlate(string value)
{
    public string Value { get; init; } = value;
}
