using Domain.Maintenances;
using SharedKernel.Exceptions;

namespace Application.Maintenances.Services;

public sealed class MaintenanceFinder(IMaintenanceRepository repository)
{
    public Maintenance Find(Guid maintenanceId, Guid userId)
    {
        var maintenance = repository.GetById(maintenanceId);
        if (
            maintenance is null
            || !maintenance.UserId.Equals(userId))
        {
            throw new MaintenanceNotFoundException(maintenanceId.ToString());
        }

        return maintenance;
    }
}
