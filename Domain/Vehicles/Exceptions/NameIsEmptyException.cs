namespace Domain.Vehicles.Exceptions;

public sealed class NameIsEmptyException() 
    : System.Exception("The name cannot be empty");
