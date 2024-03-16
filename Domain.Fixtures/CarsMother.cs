using Domain.Vehicles;

namespace Domain.Fixtures;

public static class CarsMother
{
    private const string CarPlateDefault = "0000BBB";
    
    public static Car CreateCar(CarPlate? plate = null)
    {
        return Car.Create(plate ?? CreateCarPlate());
    }

    public static CarPlate CreateCarPlate(string? value = null)
    {
        return CarPlate.Create(value ?? CarPlateDefault);
    }
}
