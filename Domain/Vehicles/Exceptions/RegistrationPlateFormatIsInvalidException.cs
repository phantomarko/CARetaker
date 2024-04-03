namespace Domain.Vehicles.Exceptions;

public sealed class RegistrationPlateFormatIsInvalidException()
    : Primitives.Exception("The plate must contain only alphanumeric characters and hyphens");

