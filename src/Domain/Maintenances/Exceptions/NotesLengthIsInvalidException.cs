namespace Domain.Maintenances.Exceptions;

public sealed class NotesLengthIsInvalidException()
    : System.Exception($"The notes length must be less than {Notes.MaximumLength}");
