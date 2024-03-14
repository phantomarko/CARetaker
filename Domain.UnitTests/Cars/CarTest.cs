using Domain.Cars;
using Domain.Fixtures;

namespace Domain.UnitTests.Cars;

[TestFixture]
internal class CarTest
{
    private static IEnumerable<TestCaseData> ValidCarData
    {
        get
        {
            yield return new TestCaseData(CarsMother.CreateCarPlate());
        }
    }

    [TestCaseSource(nameof(ValidCarData))]
    public void Constructor_Should_ReturnCar(CarPlate plate)
    {
        Car car = Car.Create(plate);

        Assert.That(car.Plate, Is.EqualTo(plate));
    }
}
