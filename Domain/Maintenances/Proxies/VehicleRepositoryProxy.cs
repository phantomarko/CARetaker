using Domain.Exceptions;
using Domain.Vehicles;

namespace Domain.Maintenances.Proxies;

public class VehicleRepositoryProxy(IVehicleRepository vehicleRepository)
    : IVehicleRepository
{
    public Task AddAsync(
        Vehicle vehicle,
        CancellationToken cancellationToken = default)
    {
        throw new MethodNotAllowedException();
    }

    public Vehicle? FindByUserAndId(Guid userId, Guid id)
    {
        return vehicleRepository.FindByUserAndId(userId, id);
    }

    public Vehicle? FindByUserAndPlate(Guid userId, RegistrationPlate plate)
    {
        throw new MethodNotAllowedException();
    }
}
