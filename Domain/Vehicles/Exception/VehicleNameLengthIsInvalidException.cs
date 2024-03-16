namespace Domain.Vehicles.Exception;

public class VehicleNameLengthIsInvalidException() 
    : System.Exception($"The vehicle name length must be less than {VehicleName.MaximumLength}")
{
}
