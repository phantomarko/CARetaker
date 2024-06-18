namespace Domain.Vehicles.Exceptions;

public sealed class RegistrationPlateLengthIsInvalidException()
    : System.Exception($"The plate length must be less than {RegistrationPlate.MaximumLength}");
