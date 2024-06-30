using Domain.Primitives;
using Domain.Vehicles.Exceptions;

namespace Domain.Vehicles;

public sealed class Vehicle : AggregateRoot
{
    private Vehicle(
        Guid id,
        Guid userId,
        Name name,
        RegistrationPlate? plate) : base(id)
    {
        UserId = userId;
        Name = name;
        Plate = plate;
    }

    public Guid UserId { get; }

    public Name Name { get; }

    public RegistrationPlate? Plate { get; }

    public static Vehicle Create(
        Guid id,
        Guid userId,
        Name name,
        RegistrationPlate? plate,
        IVehicleRepository vehicleRepository)
    {
        if (
            plate is not null 
            && vehicleRepository.FindByUserAndPlate(userId, plate) is not null)
        {
            throw new RegistrationPlateIsAlreadyInUseException();
        }

        return new Vehicle(
            id,
            userId,
            name,
            plate);
    }
}
