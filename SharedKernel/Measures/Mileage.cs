namespace SharedKernel.Measures;

public sealed record Mileage
{
    private const int MinimumValue = 0;

    private Mileage(int value, MileageUnit unit)
    {
        Value = value;
        Unit = unit;
    }

    public int Value { get; }

    public MileageUnit Unit { get; }

    public static Mileage Create(int value, string unit)
    {
        if (value < MinimumValue)
        {
            throw new MileageValueIsLessThanZeroException();
        }

        if (!Enum.TryParse(unit, false, out MileageUnit enumUnit))
        {
            throw new MileageUnitIsInvalidException();
        }

        return new Mileage(value, enumUnit);
    }
}
