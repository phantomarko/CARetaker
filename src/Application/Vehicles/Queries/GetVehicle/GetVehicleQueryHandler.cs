using Application.Abstractions.Authentication;
using Application.Abstractions.Messaging;
using Application.Vehicles.Responses;
using Application.Vehicles.Services;

namespace Application.Vehicles.Queries.GetVehicle;

public sealed class GetVehicleQueryHandler(
    IIdentityProvider identityProvider,
    VehicleFinder vehicleFinder)
    : IQueryHandler<GetVehicleQuery, VehicleResponse>
{
    public Task<VehicleResponse> Handle(
        GetVehicleQuery request,
        CancellationToken cancellationToken = default)
    {
        var vehicle = vehicleFinder.Find(
            Guid.Parse(request.VehicleId),
            identityProvider.GetAuthenticatedUserId());

        return Task.FromResult(new VehicleResponse(
            vehicle.Id.ToString(),
            vehicle.Name.Value,
            vehicle.Plate?.Value));
    }
}
