using Domain.Maintenances.Proxies;
using SharedKernel.Exceptions;

namespace Application.Maintenances.Services;

public sealed class VehicleFinder(VehicleRepositoryProxy vehicleRepository)
{
    public void GuardAgainstNotExistingVehicle(Guid vehicleId, Guid userId)
    {
        if (!VehicleExists(vehicleId, userId))
        {
            throw new VehicleNotFoundException(vehicleId.ToString());
        }
    }

    private bool VehicleExists(Guid vehicleId, Guid userId)
    {
        var vehicle = vehicleRepository.FindById(vehicleId);
        return vehicle is not null && vehicle.UserId.Equals(userId);
    }
}
