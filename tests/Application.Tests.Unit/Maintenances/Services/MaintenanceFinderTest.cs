using Application.Maintenances.Exceptions;
using Application.Maintenances.Services;
using Domain.Maintenances;
using Moq;

namespace Application.Tests.Unit.Maintenances.Services;

public class MaintenanceFinderTest
{
    private readonly Mock<IMaintenanceRepository> _repository;
    private readonly MaintenanceFinder _finder;

    public MaintenanceFinderTest()
    {
        _repository = new Mock<IMaintenanceRepository>();
        _finder = new MaintenanceFinder(_repository.Object);
    }

    [Fact]
    public void Find_Should_ThrowException_WhenRepositoryReturnsNull()
    {
        Assert.Throws<MaintenanceNotFoundException>(() => _finder.Find(
            Guid.NewGuid(),
            Guid.NewGuid()));
    }

    [Fact]
    public void Find_Should_ThrowException_WhenUserIsNotOwner()
    {
        var vehicleId = Guid.NewGuid();
        MaintenanceExists(
            Domain.Tests.Fixtures.MaintenancesMother.MakeMaintenance(
                id: vehicleId,
                userId: Guid.NewGuid()));

        Assert.Throws<MaintenanceNotFoundException>(() => _finder.Find(
            vehicleId,
            Guid.NewGuid()));
        _repository.VerifyAll();
    }

    [Fact]
    public void Find_ShouldNot_ThrowException()
    {
        var vehicleId = Guid.NewGuid();
        var userId = Guid.NewGuid();
        MaintenanceExists(
            Domain.Tests.Fixtures.MaintenancesMother.MakeMaintenance(
                id: vehicleId,
                userId: userId));

        _finder.Find(
            vehicleId,
            userId);
        _repository.VerifyAll();
    }

    private void MaintenanceExists(Maintenance maintenance)
    {
        _repository.Setup(mock => mock.GetById(maintenance.Id))
            .Returns(maintenance);
    }
}
