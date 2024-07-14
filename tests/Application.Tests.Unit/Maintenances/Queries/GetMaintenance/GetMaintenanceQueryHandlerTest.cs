using Application.Maintenances.Queries.GetMaintenance;
using Application.Maintenances.Services;
using Domain.Maintenances;
using Moq;

namespace Application.Tests.Unit.Maintenances.Queries.GetMaintenance;

public class GetMaintenanceQueryHandlerTest : AuthenticatedHandlerTestCase
{
    private readonly Mock<IMaintenanceRepository> _repository;
    private readonly GetMaintenanceQueryHandler _handler;

    public GetMaintenanceQueryHandlerTest()
    {
        _repository = new Mock<IMaintenanceRepository>();
        _handler = new GetMaintenanceQueryHandler(
            _identityProvider.Object,
            new MaintenanceFinder(_repository.Object));
    }

    [Theory]
    [ClassData(typeof(CreateMaintenanceData))]
    public async Task Handle_Should_ReturnMaintenanceResponse(Maintenance maintenance)
    {
        UserIsAuthenticated(maintenance.UserId);
        _repository.Setup(mock => mock.FindById(maintenance.Id))
            .Returns(maintenance);

        var response = await _handler.Handle(
            Fixtures.MaintenancesMother.MakeGetMaintenanceQuery(
                maintenance.Id.ToString()));

        Assert.Equal(maintenance.Id.ToString(), response.Id);
        Assert.Equal(maintenance.VehicleId.ToString(), response.VehicleId);
        Assert.Equal(maintenance.Name.Value, response.Name);
        Assert.Equal(maintenance.Description?.Value, response.Description);
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
