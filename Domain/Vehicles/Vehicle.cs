namespace Domain.Vehicles;

public abstract class Vehicle
{
    public VehicleId Id { get; protected init; }
    public VehicleName Name { get; protected set; }
}
