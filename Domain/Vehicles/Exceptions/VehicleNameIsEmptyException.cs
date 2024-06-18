namespace Domain.Vehicles.Exceptions;

public sealed class VehicleNameIsEmptyException() 
    : System.Exception("The name cannot be empty");
