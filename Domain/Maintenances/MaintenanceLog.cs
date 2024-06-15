using Domain.Maintenances.Dtos;
using Domain.Primitives;
using SharedKernel.Dates;
using SharedKernel.Finances;
using SharedKernel.Measures;

namespace Domain.Maintenances;

public sealed class MaintenanceLog : Entity
{
    private MaintenanceLog(
        Guid id,
        Mileage mileage,
        StringDate date,
        Place? place,
        Money? cost,
        Notes? notes,
        Maintenance maintenance)
        : base(id)
    {
        Mileage = mileage;
        Date = date;
        Place = place;
        Cost = cost;
        Notes = notes;
        Maintenance = maintenance;
    }

    private Mileage Mileage { get; }

    private StringDate Date { get; }

    private Place? Place { get; }

    private Money? Cost { get; }

    private Notes? Notes { get; }

    public Maintenance Maintenance { get; }

    public MaintenanceLogDto Dto => new(
        Mileage,
        Date,
        Place,
        Cost,
        Notes);

    public static MaintenanceLog Create(
        Guid id,
        MaintenanceLogDto dto,
        Maintenance maintenance)
    {
        return new MaintenanceLog(
            id,
            dto.Mileage,
            dto.Date,
            dto.Place,
            dto.Cost,
            dto.Notes,
            maintenance);
    }
}
