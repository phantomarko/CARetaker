using Domain.Fixtures;
using Domain.Vehicles;
using Domain.Vehicles.Exception;

namespace Domain.UnitTests.Vehicles;

[TestFixture]
internal class VehicleNameTest
{
    private static IEnumerable<TestCaseData> ValidNames
    {
        get
        {
            yield return new TestCaseData("A");
            yield return new TestCaseData("Str4ng3 name!");
            yield return new TestCaseData(new string('A', VehicleName.MaximumLength - 1));
            yield return new TestCaseData(new string('A', VehicleName.MaximumLength));
        }
    }

    [TestCaseSource(nameof(ValidNames))]
    public void Create_Should_ReturnInstance(string value)
    {
        VehicleName name = VehicleName.Create(value);

        Assert.That(name.Value, Is.EqualTo(value));
    }

    [Test]
    public void Create_Should_ThrowException_WhenLengthIsGreaterThanAllowed()
    {
        string value = new string('a', VehicleName.MaximumLength + 1);
        Assert.Throws<VehicleNameLengthIsInvalidException>(() => VehicleName.Create(value));
    }

    [TestCase("")]
    [TestCase("     ")]
    public void Create_Should_ThrowException_WhenValueIsEmptyOrWhiteSpace(string value)
    {
        Assert.Throws<VehicleNameIsEmptyException>(() => VehicleName.Create(value));
    }
}
