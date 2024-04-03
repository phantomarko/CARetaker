namespace Domain.Maintenances.Exceptions;

public sealed class MaintenanceNameIsEmptyException()
    : System.Exception("The name cannot be empty");
