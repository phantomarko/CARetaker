using Domain.Primitives;
using Domain.Vehicles.Exceptions;

namespace Domain.Vehicles;

public sealed class Vehicle : AggregateRoot
{
    private Vehicle(
        Guid id,
        Guid userId,
        RegistrationPlate plate,
        VehicleName name) : base(id)
    {
        UserId = userId;
        Name = name;
        Plate = plate;
    }

    public Guid UserId { get; init; }

    public RegistrationPlate Plate { get; init; }

    public VehicleName Name { get; private set; }

    public static Vehicle Create(
        Guid id,
        Guid userId,
        RegistrationPlate plate,
        VehicleName name,
        IVehicleRepository vehicleRepository)
    {
        if (vehicleRepository.FindByUserAndPlate(userId, plate) is not null)
        {
            throw new RegistrationPlateIsAlreadyInUseException();
        }

        return new Vehicle(
            id,
            userId,
            plate,
            name);
    }
}
