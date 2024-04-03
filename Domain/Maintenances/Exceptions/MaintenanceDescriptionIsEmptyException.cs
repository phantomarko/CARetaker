namespace Domain.Maintenances.Exceptions;

public sealed class MaintenanceDescriptionIsEmptyException()
    : System.Exception("The description cannot be empty");
