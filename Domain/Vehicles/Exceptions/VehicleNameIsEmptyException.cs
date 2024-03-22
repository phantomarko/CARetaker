namespace Domain.Vehicles.Exceptions;

public sealed class VehicleNameIsEmptyException() 
    : Primitives.Exception("The vehicle name can't be empty");
