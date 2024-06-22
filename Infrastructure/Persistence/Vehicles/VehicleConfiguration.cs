using Domain.Maintenances;
using Domain.Vehicles;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Vehicles;

public sealed class VehicleConfiguration : IEntityTypeConfiguration<Vehicle>
{
    private const int NameMaxLength = 100;
    private const int PlateMaxLength = 20;

    public void Configure(EntityTypeBuilder<Vehicle> builder)
    {
        builder
        .Property(e => e.Name)
        .HasConversion(
            v => v.Value,
            v => Domain.Vehicles.Name.Create(v))
        .HasMaxLength(NameMaxLength)
        .IsRequired();

        builder
        .Property(e => e.Plate)
        .HasConversion(
            v => v == null ? null : v.Value,
            v => v == null ? null : RegistrationPlate.Create(v))
        .HasMaxLength(PlateMaxLength)
        .IsRequired(false);

        builder
            .HasMany<Maintenance>()
            .WithOne()
            .HasForeignKey(e => e.VehicleId)
            .IsRequired();
    }
}
