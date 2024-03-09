using Domain.ValueObject;

namespace Domain.Entity;

public class Car(CarPlate plate)
{
    public CarPlate Plate { get; } = plate;
}
