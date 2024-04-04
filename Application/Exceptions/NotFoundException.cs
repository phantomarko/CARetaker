namespace Application.Exceptions;

public abstract class NotFoundException(string entity, string identifier)
    : System.Exception($"The {entity} with identifier {identifier} was not found");
