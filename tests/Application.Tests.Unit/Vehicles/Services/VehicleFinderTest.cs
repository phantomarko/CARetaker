using Application.Vehicles.Exceptions;
using Application.Vehicles.Services;
using Domain.Tests.Fixtures;
using Domain.Vehicles;
using Moq;

namespace Application.Tests.Unit.Vehicles.Services;

public class VehicleFinderTest
{
    private readonly Mock<IVehicleRepository> _repository;
    private readonly VehicleFinder _finder;

    public VehicleFinderTest()
    {
        _repository = new Mock<IVehicleRepository>();
        _finder = new VehicleFinder(_repository.Object);
    }
    
    [Fact]
    public void Find_Should_ThrowException_WhenRepositoryReturnsNull()
    {
        Assert.Throws<VehicleNotFoundException>(() => _finder.Find(
            Guid.NewGuid(),
            Guid.NewGuid()));
    }

    [Fact]
    public void Find_Should_ThrowException_WhenUserIsNotOwner()
    {
        var vehicleId = Guid.NewGuid();
        VehicleExists(
            VehiclesMother.MakeVehicle(id: vehicleId));

        Assert.Throws<VehicleNotFoundException>(() => _finder.Find(
            vehicleId,
            Guid.NewGuid()));
        _repository.VerifyAll();
    }

    [Fact]
    public void Find_Should_ReturnVehicle()
    {
        var vehicleId = Guid.NewGuid();
        var userId = Guid.NewGuid();
        var expectedVehicle = VehiclesMother.MakeVehicle(
            id: vehicleId,
            userId: userId);
        VehicleExists(
            expectedVehicle);

        var result = _finder.Find(
            vehicleId,
            userId);

        Assert.Equal(expectedVehicle, result);
        _repository.VerifyAll();
    }

    private void VehicleExists(Vehicle vehicle)
    {
        _repository.Setup(mock => mock.FindById(vehicle.Id))
            .Returns(vehicle);
    }
}
