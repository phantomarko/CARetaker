namespace Domain.Maintenances.Exceptions;

public sealed class NameLengthIsInvalidException()
    : System.Exception($"The name length must be less than {Name.MaximumLength}");
