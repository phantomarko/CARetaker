using Application.Maintenances.Services;
using Domain.Vehicles;

namespace Infrastructure.Maintenances;

public sealed class VehicleRepositoryClient(IVehicleRepository repository) : IVehicleClient
{
    public VehicleDto? GetVehicle(Guid vehicleId)
    {
        var vehicle = repository.FindById(vehicleId);

        if (vehicle is null)
        {
            return null;
        }

        return new VehicleDto(vehicle.Id, vehicle.UserId);
    }
}
