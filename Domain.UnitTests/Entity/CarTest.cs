using Domain.Entity;
using Domain.Fixtures;
using Domain.ValueObject;

namespace Domain.UnitTests.Entity;

[TestFixture]
internal class CarTest
{
    private static IEnumerable<TestCaseData> ValidCarData
    {
        get
        {
            yield return new TestCaseData(ValueObjectMother.CarPlate());
        }
    }

    [TestCaseSource(nameof(ValidCarData))]
    public void Constructor_Should_ReturnCar(CarPlate plate)
    {
        Car car = new(plate);

        Assert.That(car.Plate, Is.EqualTo(plate));
    }
}
