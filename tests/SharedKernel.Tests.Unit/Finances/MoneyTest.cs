using SharedKernel.Finances;

namespace SharedKernel.Tests.Unit.Finances;

public class MoneyTest
{
    public const string USD = "USD";
    public const string EUR = "EUR";

    [Theory]
    [ClassData(typeof(MoneyCreateValidData))]
    public void Create_Should_ReturnMoney(decimal value, string currency)
    {
        var money = Money.Create(value, currency);

        Assert.Equal(value, money.Value);
    }

    [Theory]
    [ClassData(typeof(MoneyCreateInvalidData))]
    public void Create_Should_ThrowException(
        Type expectedException,
        decimal value,
        string currency)
    {
        Assert.Throws(expectedException, () => Money.Create(value, currency));
    }
}

public class MoneyCreateValidData : TheoryData<decimal, string>
{
    public MoneyCreateValidData()
    {
        Add(0m, MoneyTest.USD);
        Add(0.1m, MoneyTest.USD);
        Add(2.88m, MoneyTest.USD);
        Add(0m, MoneyTest.EUR);
        Add(0.1m, MoneyTest.EUR);
        Add(2.88m, MoneyTest.EUR);
    }
}

public class MoneyCreateInvalidData : TheoryData<Type, decimal, string>
{
    public MoneyCreateInvalidData()
    {
        Add(
            typeof(MoneyValueIsLessThanZeroException),
            -0.1m,
            MoneyTest.USD);
        Add(
            typeof(CurrencyIsInvalidException),
            1m,
            MoneyTest.USD.ToLower());
    }
}
