using Application.Maintenances.Commands.CreateMaintenance;
using Application.Primitives;
using Domain.Maintenances;
using Moq;
using Tests.Application.Fixtures;

namespace Tests.Application.Unit.Maintenances.Commands;

public class CreateMaintenanceCommandHandlerTest : AbstractCommandHandlerTestCase
{
    private readonly Mock<IMaintenanceRepository> _maintenanceRepository;
    private readonly CreateMaintenanceCommandHandler _handler;
    private readonly CancellationToken _cancellationToken;

    public CreateMaintenanceCommandHandlerTest()
    {
        _maintenanceRepository = new Mock<IMaintenanceRepository>();
        _handler = new CreateMaintenanceCommandHandler(
            _identityProvider.Object,
            _maintenanceRepository.Object);
        _cancellationToken = new CancellationTokenSource().Token;
    }

    [Theory]
    [ClassData(typeof(CreateMaintenanceCommandHandlerHandleValidData))]
    public async Task Handle_Should_ReturnGuid(CreateMaintenanceCommand command)
    {
        UserIsAuthenticated();
        MaintenanceWillBePersisted();

        var result = await _handler.Handle(command, _cancellationToken);

        Assert.IsType<Guid>(result);
        _identityProvider.VerifyAll();
        _maintenanceRepository.VerifyAll();
    }

    [Fact]
    public async Task Handle_Should_ThrowException_WhenUserIsNotAuthenticated()
    {
        await Assert.ThrowsAsync<AuthorizationNeededException>(async () => await _handler.Handle(
            MaintenancesMother.MakeCreateMaintenanceCommand()));
    }

    private void MaintenanceWillBePersisted()
    {
        _maintenanceRepository.Setup(mock => mock.AddAsync(It.IsAny<Maintenance>(), _cancellationToken));
    }
}

public class CreateMaintenanceCommandHandlerHandleValidData : TheoryData<CreateMaintenanceCommand>
{
    public CreateMaintenanceCommandHandlerHandleValidData()
    {
        Add(MaintenancesMother.MakeCreateMaintenanceCommand());

        Add(MaintenancesMother.MakeCreateMaintenanceCommand(
            description: "This is a description"));
    }
}
