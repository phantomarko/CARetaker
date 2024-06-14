using Domain.Maintenances;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Maintenances;

public sealed class MaintenanceConfiguration : IEntityTypeConfiguration<Maintenance>
{
    private const int NameMaxLength = 100;
    private const int DescriptionMaxLength = 1000;

    public void Configure(EntityTypeBuilder<Maintenance> builder)
    {
        builder
            .Property(e => e.Name)
            .HasConversion(
                v => v.Value,
                v => Name.Create(v))
            .HasMaxLength(NameMaxLength)
            .IsRequired();

        builder
            .Property(e => e.Description)
            .HasConversion(
                v => v == null ? null : v.Value,
                v => v == null ? null : MaintenanceDescription.Create(v))
            .HasMaxLength(DescriptionMaxLength)
            .IsRequired(false);
    }
}
