namespace Domain.Vehicles.Exceptions;

public sealed class RegistrationPlateFormatIsInvalidException()
    : System.Exception("The plate must contain only alphanumeric characters and hyphens");

