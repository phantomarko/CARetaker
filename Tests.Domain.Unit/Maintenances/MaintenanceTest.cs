using Domain.Maintenances;
using Tests.Domain.Fixtures;

namespace Tests.Domain.Unit.Maintenances;

public class MaintenanceTest
{
    [Theory]
    [ClassData(typeof(MaintenanceCreateValidData))]
    public void Create_Should_ReturnMaintenance(
        Guid id,
        Guid userId,
        Guid vehicleId,
        MaintenanceName name,
        MaintenanceDescription? description)
    {
        var maintenance = Maintenance.Create(
            id,
            userId,
            vehicleId,
            name,
            description);

        Assert.Equal(id, maintenance.Id);
        Assert.Equal(userId, maintenance.UserId);
        Assert.Equal(vehicleId, maintenance.VehicleId);
        Assert.Equal(name, maintenance.Name);
        Assert.Equal(description, maintenance.Description);
    }
}

public class MaintenanceCreateValidData
    : TheoryData<Guid, Guid, Guid, MaintenanceName, MaintenanceDescription?>
{
    public MaintenanceCreateValidData()
    {
        Add(
            Guid.NewGuid(),
            Guid.NewGuid(),
            Guid.NewGuid(),
            MaintenancesMother.MakeMaintenanceName(),
            MaintenancesMother.MakeMaintenanceDescription());
        Add(
            Guid.NewGuid(),
            Guid.NewGuid(),
            Guid.NewGuid(),
            MaintenancesMother.MakeMaintenanceName(),
            null);
    }
}
