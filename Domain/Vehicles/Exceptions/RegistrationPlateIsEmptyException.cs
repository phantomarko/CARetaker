namespace Domain.Vehicles.Exceptions;

public sealed class RegistrationPlateIsEmptyException()
    : Primitives.Exception("The plate cannot be empty");
