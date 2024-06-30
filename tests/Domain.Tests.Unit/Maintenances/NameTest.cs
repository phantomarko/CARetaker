using Domain.Maintenances;
using Domain.Maintenances.Exceptions;

namespace Domain.Tests.Unit.Maintenances;

public class NameTest
{
    [Theory]
    [ClassData(typeof(NameCreateValidData))]
    public void Create_Should_ReturnName(string value)
    {
        var name = Name.Create(value);

        Assert.Equal(value, name.Value);
    }

    [Theory]
    [ClassData(typeof(NameCreateInvalidData))]
    public void Create_Should_ThrowException(Type expectedException, string value)
    {
        Assert.Throws(expectedException, () => Name.Create(value));
    }
}

public class NameCreateValidData : TheoryData<string>
{
    public NameCreateValidData()
    {
        Add("A");
        Add("01L CH4NG3");
        Add(new string('A', Name.MaximumLength - 1));
        Add(new string('A', Name.MaximumLength));
    }
}

public class NameCreateInvalidData : TheoryData<Type, string>
{
    public NameCreateInvalidData()
    {
        Add(
            typeof(NameIsEmptyException),
            "");
        Add(
            typeof(NameIsEmptyException),
            "     ");
        Add(
            typeof(NameLengthIsInvalidException),
            new string('A', Name.MaximumLength + 1));
    }
}
