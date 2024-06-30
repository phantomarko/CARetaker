using Bogus;
using Domain.Maintenances;
using Domain.Maintenances.Dtos;
using SharedKernel.Dates;
using SharedKernel.Finances;
using SharedKernel.Measures;

namespace Domain.Tests.Fixtures;

public static class MaintenancesMother
{
    private static Faker Faker => new();

    public static Name MakeName(string? value = null)
    {
        return Name.Create(value ?? Faker.Lorem.Word());
    }

    public static Description MakeDescription(string? value = null)
    {
        return Description.Create(value ?? Faker.Lorem.Sentence());
    }

    public static Mileage MakeMileage(int? value = null, string? unit = null)
    {
        return Mileage.Create(
            value ?? Faker.Random.Int(0, 10000000),
            unit ?? Faker.Random.Enum<MileageUnit>().ToString());
    }

    public static StringDate MakeDate(string? value = null)
    {
        return StringDate.Create(
            value ?? Faker.Date.Past().ToString(StringDate.DateFormat));
    }

    public static Place MakePlace(string? value = null)
    {
        return Place.Create(value ?? Faker.Company.CompanyName());
    }

    public static Money MakeCost(decimal? value = null, string? currency = null)
    {
        return Money.Create(
            value ?? Faker.Random.Decimal(0m, 10000m),
            currency ?? Faker.Random.ArrayElement(["USD", "EUR", "JPY"]));
    }

    public static Notes MakeNotes(string? value = null)
    {
        return Notes.Create(value ?? Faker.Lorem.Sentence());
    }

    public static MaintenanceLogDto MakeMaintenanceLogDto(
        Mileage? mileage = null,
        StringDate? date = null,
        Place? place = null,
        Money? cost = null,
        Notes? notes = null)
    {
        return new MaintenanceLogDto(
            mileage ?? MakeMileage(),
            date ?? MakeDate(),
            place,
            cost,
            notes);
    }

    public static MaintenanceLog MakeMaintenanceLog(
        Guid? id = null,
        MaintenanceLogDto? dto = null,
        Maintenance? maintenance = null)
    {
        return MaintenanceLog.Create(
            id ?? Guid.NewGuid(),
            dto ?? MakeMaintenanceLogDto(),
            maintenance ?? MakeMaintenance());
    }

    public static Maintenance MakeMaintenance(
        Guid? id = null,
        Guid? userId = null,
        Guid? vehicleId = null,
        Name? name = null,
        Description? description = null)
    {
        return Maintenance.Create(
            id ?? Guid.NewGuid(),
            userId ?? Guid.NewGuid(),
            vehicleId ?? Guid.NewGuid(),
            name ?? MakeName(),
            description);
    }
}
