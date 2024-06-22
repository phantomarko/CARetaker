using Domain.Maintenances;
using Domain.Tests.Fixtures;

namespace Domain.Tests.Unit.Maintenances;

public class MaintenanceTest
{
    [Theory]
    [ClassData(typeof(MaintenanceCreateValidData))]
    public void Create_Should_ReturnMaintenance(
        Guid id,
        Guid userId,
        Guid vehicleId,
        Name name,
        Description? description)
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
    : TheoryData<Guid, Guid, Guid, Name, Description?>
{
    public MaintenanceCreateValidData()
    {
        Add(
            Guid.NewGuid(),
            Guid.NewGuid(),
            Guid.NewGuid(),
            MaintenancesMother.MakeName(),
            MaintenancesMother.MakeDescription());
        Add(
            Guid.NewGuid(),
            Guid.NewGuid(),
            Guid.NewGuid(),
            MaintenancesMother.MakeName(),
            null);
    }
}
