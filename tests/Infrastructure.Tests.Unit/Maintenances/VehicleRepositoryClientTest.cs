using Domain.Tests.Fixtures;
using Domain.Vehicles;
using Infrastructure.Maintenances;
using Moq;

namespace Infrastructure.Tests.Unit.Maintenances;

public class VehicleRepositoryClientTest
{
    private readonly Guid _vehicleId;
    private readonly Mock<IVehicleRepository> _repository;
    private readonly VehicleRepositoryClient _client;

    public VehicleRepositoryClientTest()
    {
        _vehicleId = Guid.NewGuid();
        _repository = new Mock<IVehicleRepository>();
        _client = new VehicleRepositoryClient(_repository.Object);
    }

    [Fact]
    public void GetVehicle_Should_ReturnDto()
    {
        var vehicle = VehiclesMother.MakeVehicle(id: _vehicleId);
        _repository.Setup(repository => repository.FindById(_vehicleId))
            .Returns(vehicle);

        var dto = _client.GetVehicle(_vehicleId);

        Assert.NotNull(dto);
        Assert.Equal(vehicle.Id, dto.Id);
        Assert.Equal(vehicle.UserId, dto.UserId);
    }

    [Fact]
    public void GetVehicle_Should_ReturnNull()
    {
        var dto = _client.GetVehicle(_vehicleId);

        Assert.Null(dto);
    }
}
