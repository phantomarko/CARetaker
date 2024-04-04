using Domain.Exceptions;

namespace Domain.Vehicles.Exceptions;

public sealed class RegistrationPlateLengthIsInvalidException()
    : DomainException($"The plate length must be less than {RegistrationPlate.MaximumLength}");
