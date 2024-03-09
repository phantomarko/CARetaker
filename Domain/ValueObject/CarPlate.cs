namespace Domain.ValueObject;

public sealed class CarPlate(string value) : ValueObject<string>(value)
{
    protected override void Validate(string value)
    {
    }
}
