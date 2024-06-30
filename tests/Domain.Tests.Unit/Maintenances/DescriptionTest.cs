using Domain.Maintenances.Exceptions;
using Domain.Maintenances;

namespace Domain.Tests.Unit.Maintenances;

public class DescriptionTest
{
    [Theory]
    [ClassData(typeof(DescriptionCreateValidData))]
    public void Create_Should_ReturnDescription(string value)
    {
        var description = Description.Create(value);

        Assert.Equal(value, description.Value);
    }

    [Theory]
    [ClassData(typeof(DescriptionCreateInvalidData))]
    public void Create_Should_ThrowException(Type expectedException, string value)
    {
        Assert.Throws(expectedException, () => Description.Create(value));
    }
}

public class DescriptionCreateValidData : TheoryData<string>
{
    public DescriptionCreateValidData()
    {
        Add("A");
        Add("The engine oil has to be Castrol 5W30LL, also the oil filter has to be replaced as well");
        Add(new string('A', Description.MaximumLength - 1));
        Add(new string('A', Description.MaximumLength));
    }
}

public class DescriptionCreateInvalidData : TheoryData<Type, string>
{
    public DescriptionCreateInvalidData()
    {
        Add(
            typeof(DescriptionIsEmptyException),
            "");
        Add(
            typeof(DescriptionIsEmptyException),
            "     ");
        Add(
            typeof(DescriptionLengthIsInvalidException),
            new string('A', Description.MaximumLength + 1));
    }
}
