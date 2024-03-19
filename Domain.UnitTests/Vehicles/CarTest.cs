using Domain.Fixtures;
using Domain.Vehicles;

namespace Domain.UnitTests.Vehicles;

public class CarTest
{
    [Theory]
    [ClassData(typeof(CarCreateValidData))]
    public void Create_Should_ReturnCar(Guid id, VehicleName name, RegistrationPlate plate)
    {
        var car = Car.Create(id, name, plate);

        Assert.Equal(car.Id, id);
        Assert.Equal(car.Name, name);
        Assert.Equal(car.Plate, plate);
    }
}

public class CarCreateValidData : TheoryData<Guid, VehicleName, RegistrationPlate>
{
    public CarCreateValidData()
    {
        Add(
            Guid.NewGuid(),
            VehiclesMother.MakeVehicleName(),
            VehiclesMother.MakeRegistrationPlate());
    }
}
