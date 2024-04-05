using Domain.Maintenances.Exceptions;
using Domain.Maintenances;

namespace Tests.Domain.Unit.Maintenances;

public class MaintenanceDescriptionTest
{
    [Theory]
    [ClassData(typeof(MaintenanceDescriptionCreateValidData))]
    public void Create_Should_ReturnMaintenanceDescription(string value)
    {
        var description = MaintenanceDescription.Create(value);

        Assert.Equal(value, description.Value);
    }

    [Theory]
    [ClassData(typeof(MaintenanceDescriptionCreateInvalidData))]
    public void Create_Should_ThrowException(Type expectedException, string value)
    {
        Assert.Throws(expectedException, () => MaintenanceDescription.Create(value));
    }
}

public class MaintenanceDescriptionCreateValidData : TheoryData<string>
{
    public MaintenanceDescriptionCreateValidData()
    {
        Add("A");
        Add("The engine oil has to be Castrol 5W30LL, also the oil filter has to be replaced as well");
        Add(new string('A', MaintenanceDescription.MaximumLength - 1));
        Add(new string('A', MaintenanceDescription.MaximumLength));
    }
}

public class MaintenanceDescriptionCreateInvalidData : TheoryData<Type, string>
{
    public MaintenanceDescriptionCreateInvalidData()
    {
        Add(
            typeof(MaintenanceDescriptionIsEmptyException),
            "");
        Add(
            typeof(MaintenanceDescriptionIsEmptyException),
            "     ");
        Add(
            typeof(MaintenanceDescriptionLengthIsInvalidException),
            new string('A', MaintenanceDescription.MaximumLength + 1));
    }
}
