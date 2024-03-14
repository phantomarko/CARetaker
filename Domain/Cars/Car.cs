namespace Domain.Cars;

public sealed class Car
{
    private Car()
    {
    }

    public CarPlate Plate { get; private set; }

    public static Car Create(CarPlate plate)
    {
        return new Car()
        { 
            Plate = plate 
        };
    }
}
