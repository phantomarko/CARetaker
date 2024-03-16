using Domain.Vehicles;

namespace Domain.Fixtures;

public static class VehiclesMother
{
    private const string CarPlateDefault = "0000BBB";
    private const string VehicleNameDefault = "Some car";

    public static Car CreateCar(
        VehicleId? id = null,
        VehicleName? name = null,
        CarPlate? plate = null)
    {
        return Car.Create(
            id ?? CreateVehicleId(),
            name ?? CreateVehicleName(),
            plate ?? CreateCarPlate());
    }

    public static VehicleId CreateVehicleId(Guid? value = null)
    {
        return new VehicleId(value ?? Guid.NewGuid());
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
