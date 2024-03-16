namespace Domain.Vehicles;

public sealed class Car : Vehicle
{
    private Car(VehicleId id, VehicleName name, CarPlate plate) 
        : base(id, name)
    {
        Plate = plate;
    }

    public CarPlate Plate { get; private set; }

    public static Car Create(VehicleId id, VehicleName name, CarPlate plate)
    {
        return new Car(
            id,
            name,
            plate);
    }
}
