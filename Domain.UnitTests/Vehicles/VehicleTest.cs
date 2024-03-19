using Domain.Fixtures;
using Domain.Vehicles;

namespace Domain.UnitTests.Vehicles;

public class VehicleTest
{
    [Theory]
    [ClassData(typeof(VehicleCreateValidData))]
    public void Create_Should_ReturnVehicle(Guid id, VehicleName name, RegistrationPlate plate)
    {
        var vehicle = Vehicle.Create(id, name, plate);

        Assert.Equal(vehicle.Id, id);
        Assert.Equal(vehicle.Name, name);
        Assert.Equal(vehicle.Plate, plate);
    }
}

public class VehicleCreateValidData : TheoryData<Guid, VehicleName, RegistrationPlate>
{
    public VehicleCreateValidData()
    {
        Add(
            Guid.NewGuid(),
            VehiclesMother.MakeVehicleName(),
            VehiclesMother.MakeRegistrationPlate());
    }
}
