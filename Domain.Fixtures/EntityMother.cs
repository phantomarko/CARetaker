using Domain.Entity;
using Domain.ValueObject;

namespace Domain.Fixtures;

public static class EntityMother
{
    public static Car Car(CarPlate? plate = null)
    {
        return new Car(plate ?? ValueObjectMother.CarPlate());
    }
}
