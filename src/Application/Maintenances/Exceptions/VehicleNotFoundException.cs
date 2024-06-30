namespace Application.Maintenances.Exceptions;

public sealed class VehicleNotFoundException(string identifier)
    : Exception($"The vehicle with identifier {identifier} was not found");
