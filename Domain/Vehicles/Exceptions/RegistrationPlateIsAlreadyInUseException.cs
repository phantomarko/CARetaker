namespace Domain.Vehicles.Exceptions;

public sealed class RegistrationPlateIsAlreadyInUseException()
    : Primitives.Exception("The registration plate is already in use");
