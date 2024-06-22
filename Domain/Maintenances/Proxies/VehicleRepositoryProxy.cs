using Domain.Vehicles;

namespace Domain.Maintenances.Proxies;

public class VehicleRepositoryProxy(IVehicleRepository vehicleRepository)
    : IVehicleRepository
{
    public Task AddAsync(
        Vehicle vehicle,
        CancellationToken cancellationToken = default)
    {
        throw new NotSupportedException();
    }

    public Vehicle? FindById(Guid id)
    {
        return vehicleRepository.FindById(id);
    }

    public Vehicle? FindByUserAndPlate(Guid userId, RegistrationPlate plate)
    {
        throw new NotSupportedException();
    }
}
