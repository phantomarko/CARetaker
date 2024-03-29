namespace Domain.Vehicles.Exceptions;

public sealed class RegistrationPlateFormatIsInvalidException()
    : Primitives.Exception("The registration plate must contain only alphanumeric characters and hyphens");

