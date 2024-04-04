using Application.Abstractions;
using Application.Primitives;
using Application.Vehicles.Commands.CreateVehicle;
using Domain.Vehicles;
using Moq;
using Tests.Application.Fixtures;

namespace Tests.Application.Unit.Vehicles.Commands.CreateVehicle;

public class CreateVehicleCommandHandlerTest
{
    private readonly Mock<IIdentityProvider> _identityProvider;
    private readonly Mock<IVehicleRepository> _vehicleRepository;
    private readonly CreateVehicleCommandHandler _handler;
    private readonly CancellationToken _cancellationToken;

    public CreateVehicleCommandHandlerTest()
    {
        _identityProvider = new Mock<IIdentityProvider>();
        _vehicleRepository = new Mock<IVehicleRepository>();
        _handler = new CreateVehicleCommandHandler(
            _identityProvider.Object,
            _vehicleRepository.Object);
        _cancellationToken = new CancellationTokenSource().Token;
    }

    [Theory]
    [ClassData(typeof(CreateCarCommandHandlerHandleValidData))]
    public async Task Handle_Should_ReturnGuid(CreateVehicleCommand command)
    {
        UserIsAuthenticated();
        VehicleWillBePersisted();

        var result = await _handler.Handle(command, _cancellationToken);

        Assert.IsType<Guid>(result);
        _identityProvider.VerifyAll();
        _vehicleRepository.VerifyAll();
    }

    [Fact]
    public async Task Handle_Should_ThrowException_WhenUserIsNotAuthenticated()
    {
        await Assert.ThrowsAsync<AuthorizationNeededException>(async () => await _handler.Handle(
            VehiclesMother.MakeCreateVehicleCommand(),
            _cancellationToken));
    }

    private void UserIsAuthenticated()
    {
        _identityProvider.Setup(mock => mock.GetAuthenticatedUserId()).Returns(Guid.NewGuid());
    }

    private void VehicleWillBePersisted()
    {
        _vehicleRepository.Setup(mock => mock.AddAsync(It.IsAny<Vehicle>(), _cancellationToken));
    }
}

public class CreateCarCommandHandlerHandleValidData : TheoryData<CreateVehicleCommand>
{
    public CreateCarCommandHandlerHandleValidData()
    {
        Add(VehiclesMother.MakeCreateVehicleCommand());
    }
}
