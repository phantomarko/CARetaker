using Domain.Vehicles;

namespace Infrastructure.Persistence.Vehicles;

public class VehicleRepository(ApplicationDbContext context) : IVehicleRepository
{
    public async Task AddAsync(Vehicle vehicle, CancellationToken cancellationToken = default)
    {
        await context.Vehicles.AddAsync(vehicle);
    }
}
