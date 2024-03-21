using Domain.Vehicles;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Vehicles;

public class VehicleConfiguration : IEntityTypeConfiguration<Vehicle>
{
    private const int NameMaxLength = 50;
    private const int PlateMaxLength = 16;

    public void Configure(EntityTypeBuilder<Vehicle> builder)
    {
        builder
        .Property(e => e.Name)
        .HasConversion(
            v => v.ToString(),
            v => VehicleName.Create(v))
        .IsRequired();

        builder
        .Property(e => e.Plate)
        .HasConversion(
            v => v.ToString(),
            v => RegistrationPlate.Create(v))
        .IsRequired();
    }
}
