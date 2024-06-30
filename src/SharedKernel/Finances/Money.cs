namespace SharedKernel.Finances;

public sealed record Money
{
    private Money(decimal value, Currency currency)
    {
        Value = value;
        Currency = currency;
    }

    public decimal Value { get; }

    public Currency Currency { get; }

    public static Money Create(decimal value, string currency)
    {
        if (value < 0m)
        {
            throw new MoneyValueIsLessThanZeroException();
        }

        return new Money(value, Currency.Create(currency));
    }
}
