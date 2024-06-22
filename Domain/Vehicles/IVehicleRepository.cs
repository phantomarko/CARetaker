namespace Domain.Vehicles;

public interface IVehicleRepository
{
    Task AddAsync(
        Vehicle vehicle,
        CancellationToken cancellationToken = default);

    Vehicle? FindById(Guid id);

    Vehicle? FindByUserAndPlate(Guid userId, RegistrationPlate plate);
}
