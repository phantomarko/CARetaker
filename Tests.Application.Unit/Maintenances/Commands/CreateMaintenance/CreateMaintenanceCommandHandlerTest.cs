using Application.Exceptions;
using Application.Maintenances.Commands.CreateMaintenance;
using Domain.Maintenances;
using Domain.Maintenances.Proxies;
using Domain.Vehicles;
using Moq;

namespace Tests.Application.Unit.Maintenances.Commands.CreateMaintenance;

public class CreateMaintenanceCommandHandlerTest : AuthenticatedHandlerTestCase
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
    public async Task Handle_Should_ThrowException_WhenVehicleDoNotExists()
    {
        UserIsAuthenticated();

        await Assert.ThrowsAsync<VehicleNotFoundException>(async () =>
            await _handler.Handle(MakeCommand()));
    }

    private void MaintenanceWillBePersisted()
    {
        _maintenanceRepository.Setup(mock => mock.AddAsync(
            It.IsAny<Maintenance>(),
            _cancellationToken));
    }

    private void VehicleExists(Guid userId, Guid vehicleId)
    {
        _vehicleRepository.Setup(mock => mock.FindByUserAndId(userId, vehicleId))
            .Returns(Domain.Fixtures.VehiclesMother.MakeVehicle());
    }

    public static CreateMaintenanceCommand MakeCommand(string? description = null)
    {
        return Fixtures.MaintenancesMother.MakeCreateMaintenanceCommand(
            description: description);
    }
}

public class CreateMaintenanceCommandHandlerHandleValidData : TheoryData<CreateMaintenanceCommand>
{
    public CreateMaintenanceCommandHandlerHandleValidData()
    {
        Add(CreateMaintenanceCommandHandlerTest.MakeCommand());

        Add(CreateMaintenanceCommandHandlerTest.MakeCommand("This is a description"));
    }
}
