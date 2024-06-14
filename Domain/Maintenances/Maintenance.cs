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

    public Guid UserId { get; init; }

    public Guid VehicleId { get; init; }

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
