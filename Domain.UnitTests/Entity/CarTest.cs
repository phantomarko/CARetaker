using Domain.Entity;
using Domain.ValueObject;

namespace Domain.UnitTests.Entity;

[TestFixture]
internal class CarTest
{
    [TestCaseSource(nameof(CreateCases))]
    public void CreateTest(CarPlate plate)
    {
        Car car = new(plate);

        Assert.That(car.Plate, Is.EqualTo(plate));
    }

    public static object[] CreateCases =
    {
        new object[] { new CarPlate("7465BZD") }
    };
}
