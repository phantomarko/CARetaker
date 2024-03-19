using Domain.Primitives;

namespace Domain.Vehicles;

public sealed class Vehicle : Entity
{
    private Vehicle(
        Guid id,
        VehicleName name,
        RegistrationPlate plate) : base(id)
    {
        Name = name;
        Plate = plate;
    }

    public VehicleName Name { get; private set; }

    public RegistrationPlate Plate { get; private set; }

    public static Vehicle Create(
        Guid id,
        VehicleName name,
        RegistrationPlate plate)
    {
        return new Vehicle(
            id,
            name,
            plate);
    }
}
