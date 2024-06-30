using Application.Exceptions;
using Application.Maintenances.Queries.GetMaintenance;
using Domain.Maintenances;
using Moq;

namespace Application.Tests.Unit.Maintenances.Queries.GetMaintenance;

public class GetMaintenanceQueryHandlerTest : AuthenticatedHandlerTestCase
{
    private readonly Guid _id;
    private readonly GetMaintenanceQuery _query;
    private readonly Mock<IMaintenanceRepository> _repository;
    private readonly GetMaintenanceQueryHandler _handler;

    public GetMaintenanceQueryHandlerTest()
    {
        _id = Guid.NewGuid();
        _query = Fixtures.MaintenancesMother.MakeGetMaintenanceQuery(_id.ToString());
        _repository = new Mock<IMaintenanceRepository>();
        _handler = new GetMaintenanceQueryHandler(
            _identityProvider.Object,
            _repository.Object);
    }

    [Fact]
    public async Task Handle_Should_ThrowNotFoundException_WhenMaintenanceNotExists()
    {
        await Assert.ThrowsAsync<MaintenanceNotFoundException>(async () =>
            await _handler.Handle(_query));
    }

    [Fact]
    public async Task Handle_Should_ThrowNotFoundException_WhenUserIsNotOwner()
    {
        MaintenanceExists(
            Domain.Tests.Fixtures.MaintenancesMother.MakeMaintenance(
                id: _id,
                userId: _userId));

        await Assert.ThrowsAsync<MaintenanceNotFoundException>(async () =>
            await _handler.Handle(_query));
    }

    [Theory]
    [ClassData(typeof(CreateMaintenanceData))]
    public async Task Handle_Should_ReturnMaintenanceResponse(Maintenance maintenance)
    {
        UserIsAuthenticated(maintenance.UserId);
        MaintenanceExists(maintenance);

        var response = await _handler.Handle(
            Fixtures.MaintenancesMother.MakeGetMaintenanceQuery(
                maintenance.Id.ToString()));

        Assert.Equal(maintenance.Id.ToString(), response.Id);
        Assert.Equal(maintenance.VehicleId.ToString(), response.VehicleId);
        Assert.Equal(maintenance.Name.Value, response.Name);
        Assert.Equal(maintenance.Description?.Value, response.Description);
    }

    private void MaintenanceExists(Maintenance maintenance)
    {
        _repository.Setup(mock => mock.GetById(maintenance.Id))
            .Returns(maintenance);
    }
}

public class CreateMaintenanceData : TheoryData<Maintenance>
{
    public CreateMaintenanceData()
    {
        Add(
            Domain.Tests.Fixtures.MaintenancesMother.MakeMaintenance(
                id: Guid.NewGuid(),
                userId: Guid.NewGuid(),
                name: Domain.Tests.Fixtures.MaintenancesMother.MakeName(),
                description: Domain.Tests.Fixtures.MaintenancesMother.MakeDescription()));
        Add(
            Domain.Tests.Fixtures.MaintenancesMother.MakeMaintenance(
                id: Guid.NewGuid(),
                userId: Guid.NewGuid(),
                name: Domain.Tests.Fixtures.MaintenancesMother.MakeName(),
                description: null));
    }
}
