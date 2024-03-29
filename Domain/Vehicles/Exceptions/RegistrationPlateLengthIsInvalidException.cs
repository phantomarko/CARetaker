namespace Domain.Vehicles.Exceptions;

public sealed class RegistrationPlateLengthIsInvalidException()
    : Primitives.Exception($"The registration plate length must be less than {RegistrationPlate.MaximumLength}");
