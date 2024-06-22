using Bogus;
using Domain.Vehicles;
using Moq;

namespace Tests.Domain.Fixtures;

public class VehiclesMother
{
    private static Faker Faker => new();

    public static Vehicle MakeVehicle(
        Guid? id = null,
        Guid? userId = null,
        Name? name = null,
        RegistrationPlate? plate = null)
    {
        return Vehicle.Create(
            id ?? Guid.NewGuid(),
            userId ?? Guid.NewGuid(),
            name ?? MakeName(),
            plate,
            new Mock<IVehicleRepository>().Object);
    }

    public static Name MakeName(string? value = null)
    {
        return Name.Create(value ?? Faker.Lorem.Word());
    }

    public static RegistrationPlate MakeRegistrationPlate(string? value = null)
    {
        return RegistrationPlate.Create(value ?? Faker.Random.AlphaNumeric(8).ToUpper());
    }
}
