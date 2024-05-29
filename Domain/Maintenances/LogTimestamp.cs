using Domain.Maintenances.Exceptions;
using Domain.Primitives;

namespace Domain.Maintenances;

public sealed record LogTimestamp : DateTimeRecord
{
    private const string Format = "dd/MM/yyyy";

    private LogTimestamp(DateTime value) : base(value)
    {
    }

    public string Value => WithFormat(Format);

    public static LogTimestamp Create(string value)
    {
        try
        {
            return new LogTimestamp(CreateDateTime(value, Format));
        }
        catch (FormatException)
        {
            throw new LogTimestampFormatIsInvalidException();
        }
    }
}
