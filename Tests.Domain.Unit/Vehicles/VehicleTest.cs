using Domain.Vehicles;
using Domain.Vehicles.Exceptions;
using Moq;
using Tests.Domain.Fixtures;

namespace Tests.Domain.Unit.Vehicles;

public class VehicleTest
{
    private readonly Mock<IVehicleRepository> _vehicleRepository;

    public VehicleTest()
    {
        _vehicleRepository = new Mock<IVehicleRepository>();
    }

    [Theory]
    [ClassData(typeof(VehicleCreateValidData))]
    public void Create_Should_ReturnVehicle(
        Guid id,
        Guid userId,
        Name name,
        RegistrationPlate? plate)
    {
        if (plate is not null)
        {
            _vehicleRepository.Setup(mock => mock.FindByUserAndPlate(userId, plate));
        }

        var vehicle = Vehicle.Create(
            id,
            userId,
            name,
            plate,
            _vehicleRepository.Object);

        Assert.Equal(id, vehicle.Id);
        Assert.Equal(userId, vehicle.UserId);
        Assert.Equal(name, vehicle.Name);
        Assert.Equal(plate, vehicle.Plate);
        _vehicleRepository.VerifyAll();
    }

    [Fact]
    public void Create_Should_ThrowException_WhenPlateIsUsed()
    {
        var userId = Guid.NewGuid();
        var plate = VehiclesMother.MakeRegistrationPlate();
        _vehicleRepository.Setup(mock => mock.FindByUserAndPlate(userId, plate))
            .Returns(VehiclesMother.MakeVehicle());

        Assert.Throws<RegistrationPlateIsAlreadyInUseException>(() =>
        {
            return Vehicle.Create(
                Guid.NewGuid(),
                userId,
                VehiclesMother.MakeName(),
                plate,
                _vehicleRepository.Object);
        });

        _vehicleRepository.VerifyAll();
    }
}

public class VehicleCreateValidData
    : TheoryData<Guid, Guid, Name, RegistrationPlate?>
{
    public VehicleCreateValidData()
    {
        Add(
            Guid.NewGuid(),
            Guid.NewGuid(),
            VehiclesMother.MakeName(),
            VehiclesMother.MakeRegistrationPlate());
        Add(
            Guid.NewGuid(),
            Guid.NewGuid(),
            VehiclesMother.MakeName(),
            null);
    }
}
