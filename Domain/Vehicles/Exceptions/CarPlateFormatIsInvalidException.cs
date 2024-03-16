namespace Domain.Vehicles.Exceptions;

public sealed class CarPlateFormatIsInvalidException()
    : Primitives.Exception("The car plate is invalid")
{
}
