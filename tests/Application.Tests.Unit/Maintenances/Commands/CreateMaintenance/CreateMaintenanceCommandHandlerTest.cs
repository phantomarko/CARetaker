using Application.Maintenances.Commands.CreateMaintenance;
using Application.Maintenances.Services;
using Domain.Maintenances;
using Moq;
using SharedKernel.Responses;

namespace Application.Tests.Unit.Maintenances.Commands.CreateMaintenance;

public class CreateMaintenanceCommandHandlerTest : AuthenticatedHandlerTestCase
{
    private readonly Mock<IMaintenanceRepository> _maintenanceRepository;
    private readonly Mock<IVehicleClient> _vehicleClient;
    private readonly CreateMaintenanceCommandHandler _handler;
    private readonly CancellationToken _cancellationToken;

    public CreateMaintenanceCommandHandlerTest()
    {
        _maintenanceRepository = new Mock<IMaintenanceRepository>();
        _vehicleClient = new Mock<IVehicleClient>();
        _handler = new CreateMaintenanceCommandHandler(
            _identityProvider.Object,
            _maintenanceRepository.Object,
            new VehicleFacade(_vehicleClient.Object));
        _cancellationToken = new CancellationTokenSource().Token;
    }

    [Theory]
    [ClassData(typeof(CreateMaintenanceCommandData))]
    public async Task Handle_Should_ReturnGuid(CreateMaintenanceCommand command)
    {
        var vehicle = Fixtures.MaintenancesMother.MakeVehicleDto(
            id: new Guid(command.VehicleId),
            userId: _userId);
        VehicleExists(vehicle);
        UserIsAuthenticated(_userId);
        MaintenanceWillBePersisted();

        var result = await _handler.Handle(command, _cancellationToken);

        Assert.IsType<ResourceCreatedResponse>(result);
        Assert.True(Guid.TryParse(result.Id, out Guid guid));
        _identityProvider.VerifyAll();
        _maintenanceRepository.VerifyAll();
        _vehicleClient.VerifyAll();
    }

    private void MaintenanceWillBePersisted()
    {
        _maintenanceRepository.Setup(mock => mock.AddAsync(
            It.IsAny<Maintenance>(),
            _cancellationToken));
    }

    private void VehicleExists(VehicleDto vehicle)
    {
        _vehicleClient.Setup(mock => mock.GetVehicle(vehicle.Id))
            .Returns(vehicle);
    }
}

public class CreateMaintenanceCommandData : TheoryData<CreateMaintenanceCommand>
{
    public CreateMaintenanceCommandData()
    {
        Add(Fixtures.MaintenancesMother.MakeCreateMaintenanceCommand());
        Add(Fixtures.MaintenancesMother.MakeCreateMaintenanceCommand(
            description: "This is a description"));
    }
}
