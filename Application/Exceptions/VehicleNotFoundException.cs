namespace Application.Exceptions;

public sealed class VehicleNotFoundException(string identifier) : NotFoundException(EntityName, identifier)
{
    private const string EntityName = "Vehicle";
}
