using Domain.Vehicles;

namespace Domain.Fixtures;

public static class VehiclesMother
{
    private const string CarPlateDefault = "0000BBB";
    private const string VehicleNameDefault = "Some car";

    public static Car CreateCar(
        Guid? id = null,
        VehicleName? name = null,
        CarPlate? plate = null)
    {
        return Car.Create(
            id ?? CreateVehicleId(),
            name ?? CreateVehicleName(),
            plate ?? CreateCarPlate());
    }

    public static Guid CreateVehicleId(string? value = null)
    {
        return value is null ? Guid.NewGuid() : new Guid(value);
    }

    public static VehicleName CreateVehicleName(string? value = null)
    {
        return VehicleName.Create(value ?? VehicleNameDefault);
    }

    public static CarPlate CreateCarPlate(string? value = null)
    {
        return CarPlate.Create(value ?? CarPlateDefault);
    }
}
