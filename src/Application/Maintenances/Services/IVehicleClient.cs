namespace Application.Maintenances.Services;

public interface IVehicleClient
{
    VehicleDto? GetVehicle(Guid vehicleId);
}
