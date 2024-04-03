namespace Domain.Vehicles.Exceptions;

public sealed class VehicleNameIsEmptyException() 
    : Primitives.Exception("The name cannot be empty");
