namespace Domain.Vehicles.Exceptions;

public sealed class VehicleNameLengthIsInvalidException()
    : Primitives.Exception($"The name length must be less than {VehicleName.MaximumLength}");
