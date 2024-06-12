namespace Domain.Primitives;

public abstract class DomainException(string message)
    : Exception(message);
