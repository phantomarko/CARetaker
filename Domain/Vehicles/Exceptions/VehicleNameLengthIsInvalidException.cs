using Domain.Primitives;

namespace Domain.Vehicles.Exceptions;

public sealed class VehicleNameLengthIsInvalidException()
    : DomainException($"The name length must be less than {VehicleName.MaximumLength}");
