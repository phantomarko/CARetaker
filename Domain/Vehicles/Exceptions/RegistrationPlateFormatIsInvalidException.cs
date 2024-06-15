using Domain.Primitives;

namespace Domain.Vehicles.Exceptions;

public sealed class RegistrationPlateFormatIsInvalidException()
    : DomainException("The plate must contain only alphanumeric characters and hyphens");

