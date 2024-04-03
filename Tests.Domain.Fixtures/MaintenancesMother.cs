using Domain.Maintenances;

namespace Tests.Domain.Fixtures;

public static class MaintenancesMother
{
    private const string NameDefault = "Change ABC";
    private const string DescriptionDefault = "The ABC has to be changed carefully";

    public static MaintenanceName MakeMaintenanceName(string? value = null)
    {
        return MaintenanceName.Create(value ?? NameDefault);
    }

    public static MaintenanceDescription MakeMaintenanceDescription(string? value = null)
    {
        return MaintenanceDescription.Create(value ?? DescriptionDefault);
    }
}
