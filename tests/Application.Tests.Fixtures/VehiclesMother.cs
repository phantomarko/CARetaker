using Application.Vehicles.Commands.CreateVehicle;
using Application.Vehicles.Queries.GetVehicle;

namespace Application.Tests.Fixtures;

public class VehiclesMother
{
    private const string NameDefault = "Example Car";
    private const string PlateDefault = "0000BBB";

    public static CreateVehicleCommand MakeCreateVehicleCommand(
        string? name = null,
        string? plate = null)
    {
        return new CreateVehicleCommand(
            name ?? NameDefault,
            plate ?? PlateDefault);
    }

    public static GetVehicleQuery MakeGetVehicleQuery(string? vehicleId = null)
    {
        return new GetVehicleQuery(vehicleId ?? Guid.NewGuid().ToString());
    }
}
