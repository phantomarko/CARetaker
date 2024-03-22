using Domain.Vehicles.Exceptions;
using Domain.Vehicles;

namespace Tests.Domain.Unit.Vehicles;

public class VehicleNameTest
{
    [Theory]
    [ClassData(typeof(VehicleNameCreateValidData))]
    public void Create_Should_ReturnVehicleName(string value)
    {
        var name = VehicleName.Create(value);

        Assert.Equal(name.Value, value);
    }

    [Theory]
    [ClassData(typeof(VehicleNameCreateInvalidData))]
    public void Create_Should_ThrowException(Type expectedException, string value)
    {
        Assert.Throws(expectedException, () => VehicleName.Create(value));
    }
}

public class VehicleNameCreateValidData : TheoryData<string>
{
    public VehicleNameCreateValidData()
    {
        Add("A");
        Add("Str4ng3 name!");
        Add(new string('A', VehicleName.MaximumLength - 1));
        Add(new string('A', VehicleName.MaximumLength));
    }
}

public class VehicleNameCreateInvalidData : TheoryData<Type, string>
{
    public VehicleNameCreateInvalidData()
    {
        Add(
            typeof(VehicleNameIsEmptyException),
            "");
        Add(
            typeof(VehicleNameIsEmptyException),
            "     ");
        Add(
            typeof(VehicleNameLengthIsInvalidException),
            new string('A', VehicleName.MaximumLength + 1));
    }
}
