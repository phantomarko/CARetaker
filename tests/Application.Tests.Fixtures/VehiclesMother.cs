using Application.Vehicles.Commands.CreateVehicle;

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
}
