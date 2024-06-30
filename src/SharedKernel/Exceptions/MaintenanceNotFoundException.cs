namespace SharedKernel.Exceptions;

public sealed class MaintenanceNotFoundException(string identifier)
    : NotFoundException(EntityName, identifier)
{
    private const string EntityName = "Maintenance";
}
