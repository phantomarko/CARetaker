using MediatR;

namespace Application.Maintenances.Queries.GetMaintenance;

public sealed record GetMaintenanceQuery(string MaintenanceId)
    : IRequest<GetMaintenanceQueryResponse>;
