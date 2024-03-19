using Application.Vehicles.Command.CreateCar;

namespace Application.Fixtures;

public static class VehiclesMother
{
    private const string NameDefault = "Example Car";
    private const string PlateDefault = "0000BBB";

    public static CreateCarCommand MakeCreateProductCommand(
        string? name = null, string? plate = null)
    {
        return new CreateCarCommand(
            name ?? NameDefault,
            plate ?? PlateDefault);
    }
}
