using Application.Vehicles.Queries.GetVehicle;
using Application.Vehicles.Services;
using Domain.Vehicles;
using Moq;

namespace Application.Tests.Unit.Vehicles.Queries;

public class GetVehicleQueryHandlerTest : AuthenticatedHandlerTestCase
{
    private readonly Mock<IVehicleRepository> _repository;
    private readonly GetVehicleQueryHandler _handler;

    public GetVehicleQueryHandlerTest()
    {
        _repository = new Mock<IVehicleRepository>();
        _handler = new GetVehicleQueryHandler(
            _identityProvider.Object,
            new VehicleFinder(_repository.Object));
    }

    [Theory]
    [ClassData(typeof(CreateVehicleData))]
    public async Task Handle_Should_ReturnVehicleResponse(Vehicle vehicle)
    {
        UserIsAuthenticated(vehicle.UserId);
        _repository.Setup(mock => mock.FindById(vehicle.Id))
            .Returns(vehicle);

        var response = await _handler.Handle(
            Fixtures.VehiclesMother.MakeGetVehicleQuery(vehicle.Id.ToString()));

        Assert.Equal(vehicle.Id.ToString(), response.Id);
        Assert.Equal(vehicle.Name.Value, response.Name);
        Assert.Equal(vehicle.Plate?.Value, response.Plate);
    }
}

public class CreateVehicleData : TheoryData<Vehicle>
{
    public CreateVehicleData()
    {
        Add(
            Domain.Tests.Fixtures.VehiclesMother.MakeVehicle(
                id: Guid.NewGuid(),
                userId: Guid.NewGuid(),
                name: Domain.Tests.Fixtures.VehiclesMother.MakeName(),
                plate: null));
        Add(
            Domain.Tests.Fixtures.VehiclesMother.MakeVehicle(
                id: Guid.NewGuid(),
                userId: Guid.NewGuid(),
                name: Domain.Tests.Fixtures.VehiclesMother.MakeName(),
                plate: Domain.Tests.Fixtures.VehiclesMother.MakeRegistrationPlate()));
    }
}
