using Application.Maintenances.Exceptions;
using Application.Maintenances.Services;
using Domain.Maintenances.Proxies;
using Domain.Vehicles;
using Moq;

namespace Application.Tests.Unit.Maintenances.Services;

public class VehicleFinderTest
{
    private readonly Mock<IVehicleRepository> _repository;
    private readonly VehicleFinder _finder;

    public VehicleFinderTest()
    {
        _repository = new Mock<IVehicleRepository>();
        _finder = new VehicleFinder(
            new VehicleRepositoryProxy(_repository.Object));
    }

    [Fact]
    public void GuardAgainstNotExistingVehicle_Should_ThrowException_WhenRepositoryReturnsNull()
    {
        Assert.Throws<VehicleNotFoundException>(() => _finder.GuardAgainstNotExistingVehicle(
            Guid.NewGuid(),
            Guid.NewGuid()));
    }

    [Fact]
    public void GuardAgainstNotExistingVehicle_Should_ThrowException_WhenUserIsNotTheOwner()
    {
        var vehicleId = Guid.NewGuid();
        VehicleExists(Domain.Tests.Fixtures.VehiclesMother.MakeVehicle(
            id: vehicleId,
            userId: Guid.NewGuid()));

        Assert.Throws<VehicleNotFoundException>(() => _finder.GuardAgainstNotExistingVehicle(
            vehicleId,
            Guid.NewGuid()));
        _repository.VerifyAll();
    }

    [Fact]
    public void GuardAgainstNotExistingVehicle_ShouldNot_ThrowException()
    {
        var vehicleId = Guid.NewGuid();
        var userId = Guid.NewGuid();
        VehicleExists(Domain.Tests.Fixtures.VehiclesMother.MakeVehicle(
            id: vehicleId,
            userId: userId));

        _finder.GuardAgainstNotExistingVehicle(
            vehicleId,
            userId);
        _repository.VerifyAll();
    }

    private void VehicleExists(Vehicle vehicle)
    {
        _repository.Setup(mock => mock.FindById(vehicle.Id))
            .Returns(vehicle);
    }
}
