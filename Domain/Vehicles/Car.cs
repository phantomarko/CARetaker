namespace Domain.Vehicles;

public sealed class Car : Vehicle
{
    private Car()
    {
    }

    public CarPlate Plate { get; private set; }

    public static Car Create(VehicleId id, VehicleName name, CarPlate plate)
    {
        return new Car()
        {
            Id = id,
            Name = name,
            Plate = plate
        };
    }
}
