using Domain.Maintenances;

namespace Tests.Domain.Fixtures;

public static class MaintenancesMother
{
    private const string NameDefault = "Change ABC";
    private const string DescriptionDefault = "The ABC has to be changed carefully";

    public static Name MakeName(string? value = null)
    {
        return Name.Create(value ?? NameDefault);
    }

    public static Description MakeDescription(string? value = null)
    {
        return Description.Create(value ?? DescriptionDefault);
    }
}
