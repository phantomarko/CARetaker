namespace Domain.Maintenances.Exceptions;

public sealed class DescriptionLengthIsInvalidException()
    : System.Exception($"The description length must be less than {Description.MaximumLength}");
