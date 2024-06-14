using System.Globalization;

namespace SharedKernel.Dates;

public abstract record BaseDateTime
{
    protected BaseDateTime(DateTime value) => Value = value;

    private DateTime Value { get; }

    protected string Format(string format) => Value.ToString(format);

    protected static DateTime CreateFromFormat(string value, string format)
    {
        return DateTime.ParseExact(value, format, CultureInfo.InvariantCulture);
    }
}
