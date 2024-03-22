namespace Domain.Vehicles.Exceptions;

public sealed class RegistrationPlateIsEmptyException()
    : Primitives.Exception("The car plate cannot be empty");
