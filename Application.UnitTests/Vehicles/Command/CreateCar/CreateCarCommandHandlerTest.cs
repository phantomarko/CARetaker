using Application.Fixtures;
using Application.Vehicles.Command.CreateCar;
using Domain.Vehicles;
using Moq;

namespace Application.UnitTests.Vehicles.Command.CreateCar;

public class CreateCarCommandHandlerTest
{
    private readonly Mock<IProductRepository> _productRepository;
    private readonly CreateCarCommandHandler _handler;

    public CreateCarCommandHandlerTest()
    {
        _productRepository = new Mock<IProductRepository>();
        _handler = new CreateCarCommandHandler(_productRepository.Object);
    }

    [Theory]
    [ClassData(typeof(CreateCarCommandHandlerHandleValidData))]
    public async Task Handle_Should_ReturnGuid(CreateCarCommand command)
    {
        var result = await _handler.Handle(command);

        _productRepository.Verify(mock => mock.Add(It.IsAny<Car>()), Times.Once);
        Assert.IsType<Guid>(result);
    }
}

public class CreateCarCommandHandlerHandleValidData : TheoryData<CreateCarCommand>
{
    public CreateCarCommandHandlerHandleValidData()
    {
        Add(VehiclesMother.MakeCreateProductCommand());
    }
}
