using Application.Maintenances.Exceptions;
using Application.Maintenances.Services;
using Domain.Maintenances;
using Domain.Tests.Fixtures;
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
        var maintenanceId = Guid.NewGuid();
        MaintenanceExists(
            Domain.Tests.Fixtures.MaintenancesMother.MakeMaintenance(
                id: maintenanceId,
                userId: Guid.NewGuid()));

        Assert.Throws<MaintenanceNotFoundException>(() => _finder.Find(
            maintenanceId,
            Guid.NewGuid()));
        _repository.VerifyAll();
    }

    [Fact]
    public void Find_Should_ReturnMaintenance()
    {
        var maintenanceId = Guid.NewGuid();
        var userId = Guid.NewGuid();
        var expectedMaintenance = MaintenancesMother.MakeMaintenance(
            id: maintenanceId,
            userId: userId);
        MaintenanceExists(
            expectedMaintenance);

        var result = _finder.Find(
            maintenanceId,
            userId);

        Assert.Equal(expectedMaintenance, result);
        _repository.VerifyAll();
    }

    private void MaintenanceExists(Maintenance maintenance)
    {
        _repository.Setup(mock => mock.FindById(maintenance.Id))
            .Returns(maintenance);
    }
}
