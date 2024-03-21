using Application.Fixtures;
using Application.Vehicles.Command.CreateVehicle;
using Domain.Vehicles;
using Moq;

namespace Application.UnitTests.Vehicles.Command.CreateVehicle;

public class CreateVehicleCommandHandlerTest
{
    private readonly Mock<IVehicleRepository> _vehicleRepository;
    private readonly CreateVehicleCommandHandler _handler;

    public CreateVehicleCommandHandlerTest()
    {
        _vehicleRepository = new Mock<IVehicleRepository>();
        _handler = new CreateVehicleCommandHandler(_vehicleRepository.Object);
    }

    [Theory]
    [ClassData(typeof(CreateCarCommandHandlerHandleValidData))]
    public async Task Handle_Should_ReturnGuid(CreateVehicleCommand command)
    {
        var cancellationTokenSource = new CancellationTokenSource();
        var result = await _handler.Handle(command, cancellationTokenSource.Token);

        _vehicleRepository.Verify(mock => mock.AddAsync(It.IsAny<Vehicle>(), cancellationTokenSource.Token), Times.Once);
        Assert.IsType<Guid>(result);
    }
}

public class CreateCarCommandHandlerHandleValidData : TheoryData<CreateVehicleCommand>
{
    public CreateCarCommandHandlerHandleValidData()
    {
        Add(VehiclesMother.MakeCreateVehicleCommand());
    }
}
