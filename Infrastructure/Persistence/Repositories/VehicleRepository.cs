using Domain.Vehicles;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Repositories;

public class VehicleRepository(ApplicationContext context) : IVehicleRepository
{
    public void Add(Vehicle vehicle)
    {
        context.Add<Vehicle>(vehicle);
    }
}
