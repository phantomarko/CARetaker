using Domain.Maintenances;
using Domain.Maintenances.Exceptions;

namespace Tests.Domain.Unit.Maintenances;

public class PlaceTest
{
    [Theory]
    [ClassData(typeof(PlaceCreateValidData))]
    public void Create_Should_ReturnPlace(string value)
    {
        var place = Place.Create(value);

        Assert.Equal(value, place.Value);
    }

    [Theory]
    [ClassData(typeof(PlaceCreateInvalidData))]
    public void Create_Should_ThrowException(Type expectedException, string value)
    {
        Assert.Throws(expectedException, () => Place.Create(value));
    }
}

public class PlaceCreateValidData : TheoryData<string>
{
    public PlaceCreateValidData()
    {
        Add("Buddys Workshop");
        Add(new string('A', Place.MaximumLength - 1));
        Add(new string('A', Place.MaximumLength));
    }
}

public class PlaceCreateInvalidData : TheoryData<Type, string>
{
    public PlaceCreateInvalidData()
    {
        Add(
            typeof(PlaceIsEmptyException),
            "");
        Add(
            typeof(PlaceIsEmptyException),
            "     ");
        Add(
            typeof(PlaceLengthIsInvalidException),
            new string('A', Place.MaximumLength + 1));
    }
}
