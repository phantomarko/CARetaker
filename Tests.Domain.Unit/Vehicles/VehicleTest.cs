using Domain.Vehicles;
using Tests.Domain.Fixtures;

namespace Tests.Domain.Unit.Vehicles;

public class VehicleTest
{
    [Theory]
    [ClassData(typeof(VehicleCreateValidData))]
    public void Create_Should_ReturnVehicle(Guid id, Guid userId, VehicleName name, RegistrationPlate plate)
    {
        var vehicle = Vehicle.Create(id, userId, plate, name);

        Assert.Equal(vehicle.Id, id);
        Assert.Equal(vehicle.UserId, userId);
        Assert.Equal(vehicle.Plate, plate);
        Assert.Equal(vehicle.Name, name);
    }
}

public class VehicleCreateValidData : TheoryData<Guid, Guid, VehicleName, RegistrationPlate>
{
    public VehicleCreateValidData()
    {
        Add(
            Guid.NewGuid(),
            Guid.NewGuid(),
            VehiclesMother.MakeVehicleName(),
            VehiclesMother.MakeRegistrationPlate());
    }
}
