using Domain.Fixtures;
using Domain.Vehicles;

namespace Domain.UnitTests.Vehicles;

public class CarTest
{
    [Theory]
    [ClassData(typeof(CarCreateValidData))]
    public void Create_Should_ReturnCar(Guid id, VehicleName name, CarPlate plate)
    {
        Car car = Car.Create(id, name, plate);

        Assert.Equal(car.Id, id);
        Assert.Equal(car.Name, name);
        Assert.Equal(car.Plate, plate);
    }
}

public class CarCreateValidData : TheoryData<Guid, VehicleName, CarPlate>
{
    public CarCreateValidData()
    {
        Add(
            VehiclesMother.CreateVehicleId(),
            VehiclesMother.CreateVehicleName(),
            VehiclesMother.CreateCarPlate());
    }
}
