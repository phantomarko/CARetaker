namespace Domain.Exceptions;

public abstract class DomainException(string message) : System.Exception(message)
{
}
