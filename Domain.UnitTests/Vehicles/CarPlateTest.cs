using Domain.Vehicles.Exceptions;
using Domain.Vehicles;

namespace Domain.UnitTests.Vehicles;

public class CarPlateTest
{
    [Theory]
    [InlineData("7465BZD")] // EU
    [InlineData("H7465BZD")] // EU historical
    [InlineData("MA2888AZ")] // provinces with 2 letter
    [InlineData("M2888AZ")] // provinces with one letter
    public void Create_Should_ReturnCarPlate(string value)
    {
        var plate = CarPlate.Create(value);

        Assert.Equal(plate.Value, value);
    }

    [Theory]
    [InlineData("")]
    [InlineData("carplate")]
    [InlineData("7465bzd")]
    [InlineData("h7465bzd")]
    [InlineData("ma2888az")]
    [InlineData("m2888az")]
    public void Create_Should_ThrowCarPlateFormatIsInvalidException(string value)
    {
        Assert.Throws<CarPlateFormatIsInvalidException>(() => CarPlate.Create(value));
    }
}
