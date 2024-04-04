using Domain.Maintenances;

namespace Infrastructure.Persistence.Maintenances;

public sealed class MaintenanceRepository : IMaintenanceRepository
{
    public Task AddAsync(
        Maintenance maintenance,
        CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }
}
