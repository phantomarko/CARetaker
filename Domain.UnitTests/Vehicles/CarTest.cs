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
            yield return new TestCaseData(VehiclesMother.CreateVehicleName(), VehiclesMother.CreateCarPlate());
        }
    }

    [TestCaseSource(nameof(ValidCreateData))]
    public void Create_Should_ReturnInstance(VehicleName name, CarPlate plate)
    {
        Car car = Car.Create(name, plate);

        Assert.That(car.Name, Is.EqualTo(name));
        Assert.That(car.Plate, Is.EqualTo(plate));
    }
}
