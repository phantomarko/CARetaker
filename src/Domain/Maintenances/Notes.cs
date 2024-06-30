using Domain.Maintenances.Exceptions;

namespace Domain.Maintenances;

public sealed record Notes
{
    public const int MaximumLength = 100;

    private Notes(string value) => Value = value;

    public string Value { get; }

    public static Notes Create(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            throw new NotesIsEmptyException();
        }

        if (MaximumLength < value.Length)
        {
            throw new NotesLengthIsInvalidException();
        }

        return new Notes(value);
    }
}
