using Domain.Maintenances;
using Domain.Maintenances.Exceptions;

namespace Tests.Domain.Unit.Maintenances;

public class MaintenanceNameTest
{
    [Theory]
    [ClassData(typeof(MaintenanceNameCreateValidData))]
    public void Create_Should_ReturnMaintenanceName(string value)
    {
        var name = MaintenanceName.Create(value);

        Assert.Equal(name.Value, value);
    }

    [Theory]
    [ClassData(typeof(MaintenanceNameCreateInvalidData))]
    public void Create_Should_ThrowException(Type expectedException, string value)
    {
        Assert.Throws(expectedException, () => MaintenanceName.Create(value));
    }
}

public class MaintenanceNameCreateValidData : TheoryData<string>
{
    public MaintenanceNameCreateValidData()
    {
        Add("A");
        Add("01L CH4NG3");
        Add(new string('A', MaintenanceName.MaximumLength - 1));
        Add(new string('A', MaintenanceName.MaximumLength));
    }
}

public class MaintenanceNameCreateInvalidData : TheoryData<Type, string>
{
    public MaintenanceNameCreateInvalidData()
    {
        Add(
            typeof(MaintenanceNameIsEmptyException),
            "");
        Add(
            typeof(MaintenanceNameIsEmptyException),
            "     ");
        Add(
            typeof(MaintenanceNameLengthIsInvalidException),
            new string('A', MaintenanceName.MaximumLength + 1));
    }
}
