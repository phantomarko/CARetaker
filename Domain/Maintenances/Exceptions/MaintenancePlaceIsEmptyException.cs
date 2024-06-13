namespace Domain.Maintenances.Exceptions;

public sealed class MaintenancePlaceIsEmptyException()
    : System.Exception("The place cannot be empty");
