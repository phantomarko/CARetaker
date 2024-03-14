using Domain.Cars;
using Domain.Cars.Exception;

namespace Domain.UnitTests.Cars;

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
    public void Constructor_Should_ThrowException(string value)
    {
        Assert.Throws<InvalidCarPlateException>(() => CarPlate.Create(value));
    }
}
