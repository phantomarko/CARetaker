namespace Domain.Maintenances.Exceptions;

public sealed class MaintenanceNameLengthIsInvalidException()
    : System.Exception($"The name length must be less than {MaintenanceName.MaximumLength}");
