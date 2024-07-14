using Application.Vehicles.Exceptions;
using Domain.Vehicles;

namespace Application.Vehicles.Services;

public sealed class VehicleFinder(IVehicleRepository repository)
{
    public Vehicle Find(Guid vehicleId, Guid userId)
    {
        var vehicle = repository.FindById(vehicleId);
        if (
            vehicle is null
            || !vehicle.UserId.Equals(userId))
        {
            throw new VehicleNotFoundException();
        }

        return vehicle;
    }
}
