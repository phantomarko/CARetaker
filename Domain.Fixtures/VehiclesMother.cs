using Domain.Vehicles;

namespace Domain.Fixtures;

public static class VehiclesMother
{
    private const string VehicleNameDefault = "Some car";
    private const string PlateDefault = "0000BBB";

    public static Car MakeCar(
        Guid? id = null,
        VehicleName? name = null,
        RegistrationPlate? plate = null)
    {
        return Car.Create(
            id ?? Guid.NewGuid(),
            name ?? MakeVehicleName(),
            plate ?? MakeRegistrationPlate());
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
