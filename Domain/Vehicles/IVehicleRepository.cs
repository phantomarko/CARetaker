namespace Domain.Vehicles;

public interface IVehicleRepository
{
    Task AddAsync(Vehicle vehicle, CancellationToken cancellationToken = default);

    Vehicle? FindByUserAndPlate(Guid userId, RegistrationPlate plate);
}
