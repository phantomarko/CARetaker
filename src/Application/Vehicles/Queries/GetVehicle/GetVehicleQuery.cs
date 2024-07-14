using Application.Abstractions.Messaging;
using Application.Vehicles.Responses;

namespace Application.Vehicles.Queries.GetVehicle;

public sealed record GetVehicleQuery(string VehicleId)
    : IQuery<VehicleResponse>;
