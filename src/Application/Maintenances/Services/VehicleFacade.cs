using Application.Maintenances.Exceptions;

namespace Application.Maintenances.Services;

public sealed class VehicleFacade(IVehicleClient client)
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
        var vehicle = client.GetVehicle(vehicleId);
        return vehicle is not null && vehicle.UserId.Equals(userId);
    }
}
