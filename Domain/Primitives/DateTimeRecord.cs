using System.Globalization;

namespace Domain.Primitives;

public abstract record DateTimeRecord
{
    protected DateTimeRecord(DateTime value) => Value = value;

    private DateTime Value { get; init; }

    protected string WithFormat(string format)
    {
        return Value.ToString(format);
    }

    protected static DateTime CreateDateTime(string value, string format)
    {
        return DateTime.ParseExact(value, format, CultureInfo.InvariantCulture);
    }
}
