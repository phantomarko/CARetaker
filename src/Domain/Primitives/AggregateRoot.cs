namespace Domain.Primitives;

public abstract class AggregateRoot : Entity
{
    protected AggregateRoot(Guid id) : base(id)
    {
        CreatedAt = DateTime.UtcNow;
        RefreshLastUpdate();
    }

    public DateTime CreatedAt { get; private init; }

    public DateTime UpdatedAt { get; private set; }

    protected void RefreshLastUpdate()
    {
        UpdatedAt = DateTime.UtcNow;
    }
}
