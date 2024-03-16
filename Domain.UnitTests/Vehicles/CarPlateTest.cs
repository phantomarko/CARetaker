using Domain.Vehicles;
using Domain.Vehicles.Exception;

namespace Domain.UnitTests.Vehicles;

[TestFixture]
internal class CarPlateTest
{
    [TestCase("7465BZD")] // EU
    [TestCase("H7465BZD")] // EU historical
    [TestCase("MA2888AZ")] // provinces with 2 letter
    [TestCase("M2888AZ")] // provinces with one letter
    public void Create_Should_ReturnCarPlate(string value)
    {
        CarPlate plate = CarPlate.Create(value);

        Assert.That(plate.Value, Is.EqualTo(value));
    }

    [TestCase("")]
    [TestCase("carplate")]
    [TestCase("7465bzd")]
    [TestCase("h7465bzd")]
    [TestCase("ma2888az")]
    [TestCase("m2888az")]
    public void Create_Should_ThrowCarPlateFormatIsInvalidException(string value)
    {
        Assert.Throws<CarPlateFormatIsInvalidException>(() => CarPlate.Create(value));
    }
}
