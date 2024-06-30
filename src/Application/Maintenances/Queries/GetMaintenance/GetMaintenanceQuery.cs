using Application.Abstractions.Messaging;
using Application.Maintenances.Responses;

namespace Application.Maintenances.Queries.GetMaintenance;

public sealed record GetMaintenanceQuery(string MaintenanceId)
    : IQuery<MaintenanceResponse>;
