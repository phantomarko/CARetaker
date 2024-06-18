namespace Domain.Vehicles.Exceptions;

public sealed class RegistrationPlateIsAlreadyInUseException()
    : System.Exception("The plate is already in use");
