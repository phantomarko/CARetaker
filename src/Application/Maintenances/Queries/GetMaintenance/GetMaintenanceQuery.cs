using Application.Abstractions.Messaging;

namespace Application.Maintenances.Queries.GetMaintenance;

public sealed record GetMaintenanceQuery(string MaintenanceId)
    : IQuery<MaintenanceResponse>;
