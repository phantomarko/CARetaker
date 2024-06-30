using SharedKernel.Dates;
using SharedKernel.Finances;
using SharedKernel.Measures;

namespace Domain.Maintenances.Dtos;

public sealed record MaintenanceLogDto(
    Mileage Mileage,
    StringDate Date,
    Place? Place,
    Money? Cost,
    Notes? Notes);
