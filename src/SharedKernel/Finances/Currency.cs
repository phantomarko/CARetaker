namespace SharedKernel.Finances;

public sealed record Currency
{
    private Currency(string value) => Value = value;

    public string Value { get; }

    public static Currency Create(string value)
    {
        if (!CurrencyValidator.IsValidCurrencyCode(value))
        {
            throw new CurrencyIsInvalidException();
        }

        return new Currency(value);
    }
}
