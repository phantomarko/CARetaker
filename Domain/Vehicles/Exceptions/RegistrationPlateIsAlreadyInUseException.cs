namespace Domain.Vehicles.Exceptions;

public sealed class RegistrationPlateIsAlreadyInUseException()
    : Primitives.Exception("The plate is already in use");
