using Domain.Maintenances;
using Domain.Maintenances.Exceptions;

namespace Tests.Domain.Unit.Maintenances;

public class MaintenancePlaceTest
{
    [Theory]
    [ClassData(typeof(MaintenancePlaceCreateValidData))]
    public void Create_Should_ReturnPlace(string value)
    {
        var place = MaintenancePlace.Create(value);

        Assert.Equal(value, place.Value);
    }

    [Theory]
    [ClassData(typeof(MaintenancePlaceCreateInvalidData))]
    public void Create_Should_ThrowException(Type expectedException, string value)
    {
        Assert.Throws(expectedException, () => MaintenancePlace.Create(value));
    }
}

public class MaintenancePlaceCreateValidData : TheoryData<string>
{
    public MaintenancePlaceCreateValidData()
    {
        Add("Buddys Workshop");
        Add(new string('A', MaintenancePlace.MaximumLength - 1));
        Add(new string('A', MaintenancePlace.MaximumLength));
    }
}

public class MaintenancePlaceCreateInvalidData : TheoryData<Type, string>
{
    public MaintenancePlaceCreateInvalidData()
    {
        Add(
            typeof(MaintenancePlaceIsEmptyException),
            "");
        Add(
            typeof(MaintenancePlaceIsEmptyException),
            "     ");
        Add(
            typeof(MaintenancePlaceLengthIsInvalidException),
            new string('A', MaintenancePlace.MaximumLength + 1));
    }
}
