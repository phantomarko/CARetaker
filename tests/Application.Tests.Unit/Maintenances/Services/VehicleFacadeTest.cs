using Application.Maintenances.Exceptions;
using Application.Maintenances.Services;
using Moq;

namespace Application.Tests.Unit.Maintenances.Services;

public class VehicleFacadeTest
{
    private readonly Mock<IVehicleClient> _client;
    private readonly VehicleFacade _facade;

    public VehicleFacadeTest()
    {
        _client = new Mock<IVehicleClient>();
        _facade = new VehicleFacade(_client.Object);
    }

    [Fact]
    public void GuardAgainstNotExistingVehicle_Should_ThrowException_WhenRepositoryReturnsNull()
    {
        Assert.Throws<VehicleNotFoundException>(() => _facade.GuardAgainstNotExistingVehicle(
            Guid.NewGuid(),
            Guid.NewGuid()));
    }

    [Fact]
    public void GuardAgainstNotExistingVehicle_Should_ThrowException_WhenUserIsNotTheOwner()
    {
        var vehicleId = Guid.NewGuid();
        VehicleExists(Fixtures.MaintenancesMother.MakeVehicleDto(
            id: vehicleId,
            userId: Guid.NewGuid()));

        Assert.Throws<VehicleNotFoundException>(() => _facade.GuardAgainstNotExistingVehicle(
            vehicleId,
            Guid.NewGuid()));
        _client.VerifyAll();
    }

    [Fact]
    public void GuardAgainstNotExistingVehicle_ShouldNot_ThrowException()
    {
        var vehicleId = Guid.NewGuid();
        var userId = Guid.NewGuid();
        VehicleExists(Fixtures.MaintenancesMother.MakeVehicleDto(
            id: vehicleId,
            userId: userId));

        _facade.GuardAgainstNotExistingVehicle(
            vehicleId,
            userId);
        _client.VerifyAll();
    }

    private void VehicleExists(VehicleDto vehicle)
    {
        _client.Setup(mock => mock.GetVehicle(vehicle.Id))
            .Returns(vehicle);
    }
}
