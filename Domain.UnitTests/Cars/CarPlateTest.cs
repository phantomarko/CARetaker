using Domain.Cars;

namespace Domain.UnitTests.Cars;

[TestFixture]
internal class CarPlateTest
{
    [TestCase("7465BZD")] // UE
    [TestCase("H7465BZD")] // UE+historical
    [TestCase("MA2888AZ")] // provinces
    public void Constructor_Should_ReturnCarPlate(string value)
    {
        CarPlate plate = CarPlate.Create(value);

        Assert.That(plate.Value, Is.EqualTo(value));
    }
}
