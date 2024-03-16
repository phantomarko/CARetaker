using Domain.Fixtures;
using Domain.Vehicles;

namespace Domain.UnitTests.Vehicles;

[TestFixture]
internal class CarTest
{
    private static IEnumerable<TestCaseData> ValidCreateData
    {
        get
        {
            yield return new TestCaseData(
                VehiclesMother.CreateVehicleId(),
                VehiclesMother.CreateVehicleName(),
                VehiclesMother.CreateCarPlate());
        }
    }

    [TestCaseSource(nameof(ValidCreateData))]
    public void Create_Should_ReturnCar(VehicleId id, VehicleName name, CarPlate plate)
    {
        Car car = Car.Create(id, name, plate);

        Assert.That(car.Id, Is.EqualTo(id));
        Assert.That(car.Name, Is.EqualTo(name));
        Assert.That(car.Plate, Is.EqualTo(plate));
    }
}
