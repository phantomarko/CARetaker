using Domain.Users;
using Domain.Vehicles;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Users;

public sealed class UserConfiguration : IEntityTypeConfiguration<User>
{
    private const int EmailMaxLength = 150;

    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder
        .Property(e => e.Email)
        .HasConversion(
            v => v.Value,
        v => Email.Create(v))
        .HasMaxLength(EmailMaxLength)
        .IsRequired();

        builder
        .HasIndex(b => b.Email)
        .IsUnique();

        builder
            .HasMany<Vehicle>()
            .WithOne()
            .HasForeignKey(e => e.UserId)
            .IsRequired();
    }
}
