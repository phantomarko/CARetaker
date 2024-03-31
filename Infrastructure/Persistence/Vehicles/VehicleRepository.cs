using Domain.Vehicles;

namespace Infrastructure.Persistence.Vehicles;

public sealed class VehicleRepository(ApplicationDbContext context) : IVehicleRepository
{
    public async Task AddAsync(Vehicle vehicle, CancellationToken cancellationToken = default)
    {
        await context.Vehicles.AddAsync(vehicle);
    }

    public Vehicle? FindByUserAndPlate(Guid userId, RegistrationPlate plate)
    {
        return context.Vehicles.FirstOrDefault(vehicle =>
            vehicle.Plate == plate && vehicle.UserId == userId);
    }
}
