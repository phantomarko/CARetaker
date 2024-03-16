namespace Domain.Vehicles;

public abstract class Vehicle
{
    protected Vehicle(VehicleId id, VehicleName name)
    {
        Id = id;
        Name = name;
    }

    public VehicleId Id { get; protected init; }
    public VehicleName Name { get; protected set; }
}
