using Domain.Primitives;

namespace Domain.Vehicles;

public abstract class Vehicle : Entity
{
    protected Vehicle(Guid id, VehicleName name) : base(id)
    {
        Name = name;
    }

    public VehicleName Name { get; protected set; }
}
