using Domain.Maintenances;

namespace Infrastructure.Persistence.Maintenances;

public sealed class MaintenanceRepository(ApplicationDbContext context)
    : IMaintenanceRepository
{
    public async Task AddAsync(
        Maintenance maintenance,
        CancellationToken cancellationToken = default)
    {
        await context.Maintenances.AddAsync(
            maintenance,
            cancellationToken);
    }

    public Maintenance? FindById(Guid id)
    {
        return context.Maintenances.FirstOrDefault(maintenance => maintenance.Id == id);
    }
}
