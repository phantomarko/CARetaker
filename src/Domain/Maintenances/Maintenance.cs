using Domain.Primitives;

namespace Domain.Maintenances;

public sealed class Maintenance : AggregateRoot
{
    private Maintenance(
        Guid id,
        Guid userId,
        Guid vehicleId,
        Name name,
        Description? description) : base(id)
    {
        UserId = userId;
        VehicleId = vehicleId;
        Name = name;
        Description = description;
    }

    public Guid UserId { get; }

    public Guid VehicleId { get; }

    public Name Name { get; private set; }

    public Description? Description { get; private set; }

    public static Maintenance Create(
        Guid id,
        Guid userId,
        Guid vehicleId,
        Name name,
        Description? description)
    {
        return new Maintenance(
            id,
            userId,
            vehicleId,
            name,
            description);
    }
}
