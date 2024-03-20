namespace Ui.Api.Vehicles.Create;

public sealed record CreateVehicleRequest
{
    public string Name { get; init; }
    public string Plate { get; init; }
}
