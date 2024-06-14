namespace SharedKernel.Dates;

public sealed record StringDate : BaseDateTime
{
    private const string DateFormat = "dd/MM/yyyy";

    private StringDate(DateTime value) : base(value)
    {
    }

    public string Value
    {
        get { return Format(DateFormat); }
    }

    public static StringDate Create(string value)
    {
        try
        {
            return new StringDate(CreateFromFormat(value, DateFormat));
        }
        catch (FormatException)
        {
            throw new DateFormatIsInvalidException();
        }
    }
}
