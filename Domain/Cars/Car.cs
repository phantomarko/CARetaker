namespace Domain.Cars;

public sealed class Car(CarPlate plate)
{
    public CarPlate Plate { get; } = plate;
}
