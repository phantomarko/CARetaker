namespace Domain.ValueObject;

public abstract class ValueObject<T> where T : IConvertible, IEquatable<T>, IComparable<T>
{
    public T Value { get; }

    public ValueObject(T value)
    {
        Validate(value);
        Value = value;
    }

    public override bool Equals(object? obj)
    {
        var valueObject = obj as ValueObject<T>;
        return valueObject is not null && Value.Equals(valueObject);
    }

    public override int GetHashCode()
    {
        return Value.GetHashCode();
    }

    public override string? ToString()
    {
        return Value.ToString();
    }

    protected abstract void Validate(T value);
}
