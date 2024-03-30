using Domain.Vehicles;

namespace Tests.Domain.Fixtures;

public class VehiclesMother
{
    private const string VehicleNameDefault = "Some car";
    private const string PlateDefault = "0000BBB";

    public static Vehicle MakeVehicle(
        Guid? id = null,
        Guid? userId = null,
        RegistrationPlate? plate = null,
        VehicleName? name = null)
    {
        return Vehicle.Create(
            id ?? Guid.NewGuid(),
            userId ?? Guid.NewGuid(),
            plate ?? MakeRegistrationPlate(),
            name ?? MakeVehicleName());
    }

    public static VehicleName MakeVehicleName(string? value = null)
    {
        return VehicleName.Create(value ?? VehicleNameDefault);
    }

    public static RegistrationPlate MakeRegistrationPlate(string? value = null)
    {
        return RegistrationPlate.Create(value ?? PlateDefault);
    }
}
