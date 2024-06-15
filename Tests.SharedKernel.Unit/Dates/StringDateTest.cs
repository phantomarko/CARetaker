using SharedKernel.Dates;

namespace Tests.SharedKernel.Unit.Dates;

public class StringDateTest
{
    [Theory]
    [ClassData(typeof(StringDateCreateValidData))]
    public void Create_Should_ReturnDate(string value)
    {
        var date = StringDate.Create(value);

        Assert.Equal(value, date.Value);
    }

    [Theory]
    [ClassData(typeof(LogTimestampCreateInvalidData))]
    public void Create_Should_ThrowException(Type expectedException, string value)
    {
        Assert.Throws(expectedException, () => StringDate.Create(value));
    }
}

public class StringDateCreateValidData : TheoryData<string>
{
    public StringDateCreateValidData()
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
            typeof(DateFormatIsInvalidException),
            "A");
        Add(
            typeof(DateFormatIsInvalidException),
            "21/5/2000");
        Add(
            typeof(DateFormatIsInvalidException),
            "4/07/1972");
        Add(
            typeof(DateFormatIsInvalidException),
            "1973-12-14");
    }
}
