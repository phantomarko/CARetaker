namespace Domain.Vehicles;

public sealed class Car : Vehicle
{
    private Car()
    {
    }

    public CarPlate Plate { get; private set; }

    public static Car Create(VehicleName name, CarPlate plate)
    {
        return new Car()
        {
            Name = name,
            Plate = plate
        };
    }
}
