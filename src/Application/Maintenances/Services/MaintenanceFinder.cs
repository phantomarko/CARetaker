using Application.Maintenances.Exceptions;
using Domain.Maintenances;

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
            throw new MaintenanceNotFoundException();
        }

        return maintenance;
    }
}
