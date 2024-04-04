using Domain.Exceptions;
using Domain.Maintenances.Proxies;
using Domain.Vehicles;
using Moq;
using Tests.Domain.Fixtures;

namespace Tests.Domain.Unit.Maintenances.Proxies;

public class VehicleRepositoryProxyTest
{
    private readonly Mock<IVehicleRepository> _vehicleRepository;
    private readonly VehicleRepositoryProxy _proxy;

    public VehicleRepositoryProxyTest()
    {
        _vehicleRepository = new Mock<IVehicleRepository>();
        _proxy = new VehicleRepositoryProxy(_vehicleRepository.Object);
    }

    [Fact]
    public async Task AddAsync_Should_ThrowException()
    {
        await Assert.ThrowsAsync<MethodNotAllowedException>(
            async () => await _proxy.AddAsync(VehiclesMother.MakeVehicle()));
    }

    [Fact]
    public void FindByUserAndPlate_Should_ThrowException()
    {
        Assert.Throws<MethodNotAllowedException>(
            () => _proxy.FindByUserAndPlate(
                Guid.NewGuid(),
                VehiclesMother.MakeRegistrationPlate()));
    }

    [Fact]
    public void FindById_Should_ReturnVehicle_WhenVehicleExists()
    {
        var vehicleId = Guid.NewGuid();
        var userId = Guid.NewGuid();
        _vehicleRepository.Setup(mock => mock.FindByUserAndId(userId, vehicleId))
            .Returns(VehiclesMother.MakeVehicle());

        var vehicle = _proxy.FindByUserAndId(userId, vehicleId);

        Assert.NotNull(vehicle);
        _vehicleRepository.VerifyAll();
    }

    [Fact]
    public void FindById_Should_ReturnNull_WhenVehicleDoNotExists()
    {
        var vehicleId = Guid.NewGuid();
        var userId = Guid.NewGuid();
        _vehicleRepository.Setup(mock => mock.FindByUserAndId(userId, vehicleId));

        var vehicle = _proxy.FindByUserAndId(userId, vehicleId);

        Assert.Null(vehicle);
        _vehicleRepository.VerifyAll();
    }
}
