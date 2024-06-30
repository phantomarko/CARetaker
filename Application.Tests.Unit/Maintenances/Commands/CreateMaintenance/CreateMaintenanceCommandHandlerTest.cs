using Application.Exceptions;
using Application.Maintenances.Commands.CreateMaintenance;
using Domain.Maintenances;
using Domain.Maintenances.Proxies;
using Domain.Vehicles;
using Moq;
using SharedKernel.Responses;

namespace Application.Tests.Unit.Maintenances.Commands.CreateMaintenance;

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
        var vehicle = Domain.Tests.Fixtures.VehiclesMother.MakeVehicle(
            id: new Guid(command.VehicleId),
            userId: _userId);
        UserIsAuthenticated(_userId);
        VehicleExists(vehicle);
        MaintenanceWillBePersisted();

        var result = await _handler.Handle(command, _cancellationToken);

        Assert.IsType<ResourceCreatedResponse>(result);
        Assert.True(Guid.TryParse(result.Id, out Guid guid));
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

    [Fact]
    public async Task Handle_Should_ThrowException_WhenUserIsNotTheOwnerOfTheVehicle()
    {
        var vehicleId = Guid.NewGuid();
        var userId = Guid.NewGuid();
        var vehicle = Domain.Tests.Fixtures.VehiclesMother.MakeVehicle(
            id: vehicleId,
            userId: userId);
        UserIsAuthenticated(Guid.NewGuid());
        VehicleExists(vehicle);

        await Assert.ThrowsAsync<VehicleNotFoundException>(async () =>
            await _handler.Handle(MakeCommand(vehicleId: vehicleId.ToString())));
    }

    private void MaintenanceWillBePersisted()
    {
        _maintenanceRepository.Setup(mock => mock.AddAsync(
            It.IsAny<Maintenance>(),
            _cancellationToken));
    }

    private void VehicleExists(Vehicle vehicle)
    {
        _vehicleRepository.Setup(mock => mock.FindById(vehicle.Id))
            .Returns(vehicle);
    }

    public static CreateMaintenanceCommand MakeCommand(
        string? vehicleId = null,
        string? description = null)
    {
        return Fixtures.MaintenancesMother.MakeCreateMaintenanceCommand(
            vehicleId: vehicleId,
            description: description);
    }
}

public class CreateMaintenanceCommandHandlerHandleValidData : TheoryData<CreateMaintenanceCommand>
{
    public CreateMaintenanceCommandHandlerHandleValidData()
    {
        Add(CreateMaintenanceCommandHandlerTest.MakeCommand());

        Add(CreateMaintenanceCommandHandlerTest.MakeCommand(description: "This is a description"));
    }
}
