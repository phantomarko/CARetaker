namespace Domain.Vehicles.Exceptions;

public sealed class VehicleNameLengthIsInvalidException()
    : System.Exception($"The name length must be less than {VehicleName.MaximumLength}");
