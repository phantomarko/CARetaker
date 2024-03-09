using Domain.ValueObject;

namespace Domain.UnitTests.Entity;

[TestFixture]
internal class CarPlateTest
{
    [TestCase("7465BZD")] // UE
    [TestCase("H7465BZD")] // UE+historical
    [TestCase("MA2888AZ")] // provinces
    public void CreateTest(string value)
    {
        CarPlate plate = new(value);

        Assert.That(plate.Value, Is.EqualTo(value));
    }
}
