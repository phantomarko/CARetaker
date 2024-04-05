using Domain.Vehicles;
using Domain.Vehicles.Exceptions;
using Moq;
using Tests.Domain.Fixtures;

namespace Tests.Domain.Unit.Vehicles;

public class VehicleTest
{
    private readonly Guid _id;
    private readonly Guid _userId;
    private readonly VehicleName _name;
    private readonly RegistrationPlate _plate;
    private readonly Mock<IVehicleRepository> _vehicleRepository;

    public VehicleTest()
    {
        _id = Guid.NewGuid();
        _userId = Guid.NewGuid();
        _name = VehiclesMother.MakeVehicleName();
        _plate = VehiclesMother.MakeRegistrationPlate();
        _vehicleRepository = new Mock<IVehicleRepository>();
    }

    [Fact]
    public void Create_Should_ReturnVehicle()
    {
        _vehicleRepository.Setup(mock => mock.FindByUserAndPlate(_userId, _plate));

        var vehicle = Vehicle.Create(
            _id,
            _userId,
            _plate,
            _name,
            _vehicleRepository.Object);

        Assert.Equal(_id, vehicle.Id);
        Assert.Equal(_userId, vehicle.UserId);
        Assert.Equal(_plate, vehicle.Plate);
        Assert.Equal(_name, vehicle.Name);
        _vehicleRepository.VerifyAll();
    }

    [Fact]
    public void Create_Should_ThrowException_WhenPlateIsUsed()
    {
        _vehicleRepository.Setup(mock => mock.FindByUserAndPlate(_userId, _plate))
            .Returns(VehiclesMother.MakeVehicle());

        Assert.Throws<RegistrationPlateIsAlreadyInUseException>(() => Vehicle.Create(
            _id,
            _userId,
            _plate,
            _name,
            _vehicleRepository.Object));

        _vehicleRepository.VerifyAll();
    }
}
