using Domain.Exceptions;

namespace Domain.Vehicles.Exceptions;

public sealed class RegistrationPlateFormatIsInvalidException()
    : DomainException("The plate must contain only alphanumeric characters and hyphens");

