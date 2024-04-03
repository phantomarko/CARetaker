namespace Domain.Maintenances.Exceptions;

public sealed class MaintenanceDescriptionLengthIsInvalidException()
    : System.Exception($"The description length must be less than {MaintenanceDescription.MaximumLength}");
