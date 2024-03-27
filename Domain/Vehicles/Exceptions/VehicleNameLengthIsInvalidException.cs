namespace Domain.Vehicles.Exceptions;

public sealed class VehicleNameLengthIsInvalidException()
    : Primitives.Exception($"The vehicle name length must be less than {VehicleName.MaximumLength}");
