using Domain.Primitives;

namespace Domain.Vehicles.Exceptions;

public sealed class VehicleNameIsEmptyException() 
    : DomainException("The name cannot be empty");
