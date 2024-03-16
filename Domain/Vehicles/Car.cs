namespace Domain.Vehicles;

public sealed class Car : Vehicle
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
