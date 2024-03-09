using Domain.ValueObject;

namespace Domain.Fixtures;

public static class ValueObjectMother
{
    private const string CarPlateDefault = "0000BBB";

    public static CarPlate CarPlate(string? value = null)
    {
        return new CarPlate(value ?? CarPlateDefault);
    }
}
