using Domain.Primitives;

namespace Domain.Maintenances;

public sealed class Maintenance : AggregateRoot
{
    private Maintenance(
        Guid id,
        Guid carId,
        MaintenanceName name,
        MaintenanceDescription? description) : base(id)
    {
        CarId = carId;
        Name = name;
        Description = description;
    }

    public Guid CarId { get; init; }

    public MaintenanceName Name { get; private set; }

    public MaintenanceDescription? Description { get; private set; }

    public static Maintenance Create(
        Guid id,
        Guid carId,
        MaintenanceName name,
        MaintenanceDescription? description)
    {
        return new Maintenance(id, carId, name, description);
    }
}
