namespace Domain.Maintenances.Exceptions;

public sealed class MaintenancePlaceLengthIsInvalidException()
    : System.Exception($"The place length must be less than {MaintenancePlace.MaximumLength}");
