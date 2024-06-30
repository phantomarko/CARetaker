namespace Domain.Vehicles.Exceptions;

public sealed class RegistrationPlateIsEmptyException()
    : System.Exception("The plate cannot be empty");
