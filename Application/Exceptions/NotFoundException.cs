namespace Application.Exceptions;

public sealed class NotFoundException : System.Exception
{
    private NotFoundException(string entity, string identifier) 
        : base($"The {entity} with identifier {identifier} was not found")
    {
    }

    public static NotFoundException CreateVehicleNotFound(string identifier) =>
        new NotFoundException("Vehicle", identifier);
}
