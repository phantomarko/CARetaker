namespace Domain.Vehicles.Exceptions;

public sealed class RegistrationPlateIsEmptyException()
    : Primitives.Exception("The registration plate cannot be empty");
