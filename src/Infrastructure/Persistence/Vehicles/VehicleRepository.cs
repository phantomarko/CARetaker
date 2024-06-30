using Domain.Users;
using Domain.Vehicles;

namespace Infrastructure.Persistence.Vehicles;

public sealed class VehicleRepository(ApplicationDbContext context)
    : IVehicleRepository
{
    public async Task AddAsync(
        Vehicle vehicle,
        CancellationToken cancellationToken = default)
    {
        await context.Vehicles.AddAsync(vehicle, cancellationToken);
    }

    public Vehicle? FindById(Guid id)
    {
        return context.Vehicles.FirstOrDefault(vehicle => vehicle.Id == id);
    }

    public Vehicle? FindByUserAndPlate(Guid userId, RegistrationPlate plate)
    {
        return context.Vehicles.FirstOrDefault(vehicle =>
            vehicle.UserId == userId && vehicle.Plate == plate);
    }
}
