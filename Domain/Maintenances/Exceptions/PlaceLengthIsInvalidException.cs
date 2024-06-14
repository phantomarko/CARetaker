namespace Domain.Maintenances.Exceptions;

public sealed class PlaceLengthIsInvalidException()
    : System.Exception($"The place length must be less than {Place.MaximumLength}");
