namespace Domain.Vehicles;

public sealed class Car : Vehicle
{
    private Car(Guid id, VehicleName name, RegistrationPlate plate) 
        : base(id, name)
    {
        Plate = plate;
    }

    public RegistrationPlate Plate { get; private set; }

    public static Car Create(Guid id, VehicleName name, RegistrationPlate plate)
    {
        return new Car(
            id,
            name,
            plate);
    }
}
