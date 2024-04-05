namespace Domain.Vehicles;

public interface IVehicleRepository
{
    Task AddAsync(
        Vehicle vehicle,
        CancellationToken cancellationToken = default);

    Vehicle? FindByUserAndId(Guid userId, Guid id);

    Vehicle? FindByUserAndPlate(Guid userId, RegistrationPlate plate);
}
