using Domain.ValueObject;

namespace Domain.Entity;

public sealed class Car(CarPlate plate)
{
    public CarPlate Plate { get; } = plate;
}
