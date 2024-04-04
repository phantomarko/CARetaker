using Domain.Exceptions;

namespace Domain.Vehicles.Exceptions;

public sealed class RegistrationPlateIsEmptyException()
    : DomainException("The plate cannot be empty");
