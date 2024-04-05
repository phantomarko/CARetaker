namespace Domain.Maintenances;

public interface IMaintenanceRepository
{
    Task AddAsync(
        Maintenance maintenance,
        CancellationToken cancellationToken = default);
}
