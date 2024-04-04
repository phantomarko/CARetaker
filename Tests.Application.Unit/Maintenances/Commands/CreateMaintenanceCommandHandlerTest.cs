using Application.Exceptions;
using Application.Maintenances.Commands.CreateMaintenance;
using Domain.Maintenances;
using Domain.Maintenances.Proxies;
using Domain.Vehicles;
using Moq;

namespace Tests.Application.Unit.Maintenances.Commands;

public class CreateMaintenanceCommandHandlerTest : AbstractCommandHandlerTestCase
{
    private readonly Mock<IMaintenanceRepository> _maintenanceRepository;
    private readonly Mock<IVehicleRepository> _vehicleRepository;
    private readonly CreateMaintenanceCommandHandler _handler;
    private readonly CancellationToken _cancellationToken;

    public CreateMaintenanceCommandHandlerTest()
    {
        _maintenanceRepository = new Mock<IMaintenanceRepository>();
        _vehicleRepository = new Mock<IVehicleRepository>();
        _handler = new CreateMaintenanceCommandHandler(
            _identityProvider.Object,
            _maintenanceRepository.Object,
            new VehicleRepositoryProxy(_vehicleRepository.Object));
        _cancellationToken = new CancellationTokenSource().Token;
    }

    [Theory]
    [ClassData(typeof(CreateMaintenanceCommandHandlerHandleValidData))]
    public async Task Handle_Should_ReturnGuid(CreateMaintenanceCommand command)
    {
        UserIsAuthenticated();
        VehicleExists(_userId, new Guid(command.VehicleId));
        MaintenanceWillBePersisted();

        var result = await _handler.Handle(command, _cancellationToken);

        Assert.IsType<Guid>(result);
        _identityProvider.VerifyAll();
        _maintenanceRepository.VerifyAll();
        _vehicleRepository.VerifyAll();
    }

    [Fact]
    public async Task Handle_Should_ThrowException_WhenUserIsNotAuthenticated()
    {
        await Assert.ThrowsAsync<AuthenticatedUserRequiredException>(async () => await _handler.Handle(
            Application.Fixtures.MaintenancesMother.MakeCreateMaintenanceCommand()));
    }

    [Fact]
    public async Task Handle_Should_ThrowException_WhenVehicleDoNotExists()
    {
        UserIsAuthenticated();

        await Assert.ThrowsAsync<VehicleNotFoundException>(async () => await _handler.Handle(
            Application.Fixtures.MaintenancesMother.MakeCreateMaintenanceCommand()));
    }

    private void MaintenanceWillBePersisted()
    {
        _maintenanceRepository.Setup(mock => mock.AddAsync(It.IsAny<Maintenance>(), _cancellationToken));
    }

    private void VehicleExists(Guid userId, Guid vehicleId)
    {
        _vehicleRepository.Setup(mock => mock.FindByUserAndId(userId, vehicleId)).Returns(
            Domain.Fixtures.VehiclesMother.MakeVehicle());
    }
}

public class CreateMaintenanceCommandHandlerHandleValidData : TheoryData<CreateMaintenanceCommand>
{
    public CreateMaintenanceCommandHandlerHandleValidData()
    {
        Add(Application.Fixtures.MaintenancesMother.MakeCreateMaintenanceCommand());

        Add(Application.Fixtures.MaintenancesMother.MakeCreateMaintenanceCommand(
            description: "This is a description"));
    }
}
