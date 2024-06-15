namespace SharedKernel.Finances;

public static class CurrencyValidator
{
    public static bool IsValidCurrencyCode(string currencyCode)
    {
        try
        {
            TeixeiraSoftware.Finance.Currency.ByAlphabeticCode(currencyCode);
            return true;
        }
        catch
        {
            return false;
        }
    }
}
