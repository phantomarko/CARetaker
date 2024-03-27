using Domain.Vehicles.Exceptions;
using Domain.Vehicles;

namespace Tests.Domain.Unit.Vehicles;

public class RegistrationPlateTest
{
    [Theory]
    [InlineData("7465BZD")] // EU
    [InlineData("H7465BZD")] // EU historical
    [InlineData("MA2888AZ")] // provinces with 2 letter
    [InlineData("M2888AZ")] // provinces with one letter
    public void Create_Should_ReturnPlate(string value)
    {
        var plate = RegistrationPlate.Create(value);

        Assert.Equal(plate.Value, value);
    }

    [Theory]
    [InlineData("plate")]
    [InlineData("7465bzd")]
    [InlineData("h7465bzd")]
    [InlineData("ma2888az")]
    [InlineData("m2888az")]
    public void Create_Should_ThrowRegistrationPlateFormatIsInvalidException(string value)
    {
        Assert.Throws<RegistrationPlateFormatIsInvalidException>(() => RegistrationPlate.Create(value));
    }

    [Theory]
    [InlineData("")]
    [InlineData("       ")]
    public void Create_Should_ThrowRegistrationPlateFormatIsEmptyException(string value)
    {
        Assert.Throws<RegistrationPlateIsEmptyException>(() => RegistrationPlate.Create(value));
    }
}
