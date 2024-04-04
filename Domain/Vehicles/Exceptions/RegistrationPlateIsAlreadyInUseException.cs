using Domain.Exceptions;

namespace Domain.Vehicles.Exceptions;

public sealed class RegistrationPlateIsAlreadyInUseException()
    : DomainException("The plate is already in use");
