using Domain.Maintenances;
using Domain.Maintenances.Exceptions;

namespace Tests.Domain.Unit.Maintenances;

public class LogTimestampTest
{
    [Theory]
    [ClassData(typeof(LogTimestampCreateValidData))]
    public void Create_Should_ReturnLogTimestamp(string value)
    {
        var log = LogTimestamp.Create(value);

        Assert.Equal(value, log.Value);
    }

    [Theory]
    [ClassData(typeof(LogTimestampCreateInvalidData))]
    public void Create_Should_ThrowException(Type expectedException, string value)
    {
        Assert.Throws(expectedException, () => LogTimestamp.Create(value));
    }
}

public class LogTimestampCreateValidData : TheoryData<string>
{
    public LogTimestampCreateValidData()
    {
        Add("21/05/2000");
        Add("04/07/1972");
        Add("14/12/1973");
    }
}

public class LogTimestampCreateInvalidData : TheoryData<Type, string>
{
    public LogTimestampCreateInvalidData()
    {
        Add(
            typeof(LogTimestampFormatIsInvalidException),
            "A");
        Add(
            typeof(LogTimestampFormatIsInvalidException),
            "21/5/2000");
        Add(
            typeof(LogTimestampFormatIsInvalidException),
            "4/07/1972");
        Add(
            typeof(LogTimestampFormatIsInvalidException),
            "1973-12-14");
    }
}
