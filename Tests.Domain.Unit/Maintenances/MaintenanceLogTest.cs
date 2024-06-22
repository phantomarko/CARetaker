using Domain.Maintenances;
using Domain.Maintenances.Dtos;
using Domain.Tests.Fixtures;

namespace Domain.Tests.Unit.Maintenances;

public class MaintenanceLogTest
{
    [Theory]
    [ClassData(typeof(MaintenanceLogCreateValidData))]
    public void Create_Should_ReturnMaintenanceLog(
        Guid id,
        MaintenanceLogDto dto,
        Maintenance maintenance)
    {
        var log = MaintenanceLog.Create(
            id,
            dto,
            maintenance);

        Assert.Equal(id, log.Id);
        Assert.Equal(dto, log.Dto);
        Assert.Equal(maintenance.Id, log.Maintenance.Id);
    }
}

public class MaintenanceLogCreateValidData
    : TheoryData<Guid, MaintenanceLogDto, Maintenance>
{
    public MaintenanceLogCreateValidData()
    {
        Add(
            Guid.NewGuid(),
            MaintenancesMother.MakeMaintenanceLogDto(
                MaintenancesMother.MakeMileage(),
                MaintenancesMother.MakeDate()),
            MaintenancesMother.MakeMaintenance());
        Add(
            Guid.NewGuid(),
            MaintenancesMother.MakeMaintenanceLogDto(
                MaintenancesMother.MakeMileage(),
                MaintenancesMother.MakeDate(),
                MaintenancesMother.MakePlace(),
                MaintenancesMother.MakeCost(),
                MaintenancesMother.MakeNotes()),
            MaintenancesMother.MakeMaintenance());
    }
}
