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
            yield return new TestCaseData(VehiclesMother.CreateCarPlate());
        }
    }

    [TestCaseSource(nameof(ValidCreateData))]
    public void Create_Should_ReturnInstance(CarPlate plate)
    {
        Car car = Car.Create(plate);

        Assert.That(car.Plate, Is.EqualTo(plate));
    }
}
