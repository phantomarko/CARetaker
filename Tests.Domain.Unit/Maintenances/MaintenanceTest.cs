using Domain.Maintenances;
using Tests.Domain.Fixtures;

namespace Tests.Domain.Unit.Maintenances;

public class MaintenanceTest
{
    [Theory]
    [ClassData(typeof(MaintenanceCreateValidData))]
    public void Create_Should_ReturnMaintenance(
        Guid id,
        Guid carId,
        MaintenanceName name,
        MaintenanceDescription? description)
    {
        var maintenance = Maintenance.Create(
            id,
            carId,
            name,
            description);

        Assert.Equal(id, maintenance.Id);
        Assert.Equal(carId, maintenance.CarId);
        Assert.Equal(name, maintenance.Name);
        Assert.Equal(description, maintenance.Description);
    }
}

public class MaintenanceCreateValidData : TheoryData<Guid, Guid, MaintenanceName, MaintenanceDescription?>
{
    public MaintenanceCreateValidData()
    {
        Add(
            Guid.NewGuid(),
            Guid.NewGuid(),
            MaintenancesMother.MakeMaintenanceName(),
            MaintenancesMother.MakeMaintenanceDescription());
        Add(
            Guid.NewGuid(),
            Guid.NewGuid(),
            MaintenancesMother.MakeMaintenanceName(),
            null);
    }
}
