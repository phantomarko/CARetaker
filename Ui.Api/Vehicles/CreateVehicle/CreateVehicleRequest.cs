namespace Ui.Api.Vehicles.CreateVehicle;

public sealed record CreateVehicleRequest
{
    public string Name { get; init; }
    public string Plate { get; init; }
}
