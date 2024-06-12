using SharedKernel.Measures;

namespace Tests.SharedKernel.Unit.Measures;

public class MileageTest
{
    [Theory]
    [ClassData(typeof(MileageCreateValidData))]
    public void Create_Should_ReturnMileage(int value, string unit)
    {
        var log = Mileage.Create(value, unit);

        Assert.Equal(value, log.Value);
    }

    [Theory]
    [ClassData(typeof(MileageCreateInvalidData))]
    public void Create_Should_ThrowException(
        Type expectedException,
        int value,
        string unit)
    {
        Assert.Throws(expectedException, () => Mileage.Create(value, unit));
    }
}

public class MileageCreateValidData : TheoryData<int, string>
{
    public MileageCreateValidData()
    {
        Add(0, MileageUnit.Kilometers.ToString());
        Add(1, MileageUnit.Kilometers.ToString());
        Add(288, MileageUnit.Kilometers.ToString());
        Add(0, MileageUnit.Miles.ToString());
        Add(1, MileageUnit.Miles.ToString());
        Add(666, MileageUnit.Miles.ToString());
    }
}

public class MileageCreateInvalidData : TheoryData<Type, int, string>
{
    public MileageCreateInvalidData()
    {
        Add(
            typeof(MileageValueIsLessThanZeroException),
            -1,
            MileageUnit.Kilometers.ToString());
        Add(
            typeof(MileageUnitIsInvalidException),
            1,
            MileageUnit.Kilometers.ToString().ToUpper());
        Add(
            typeof(MileageUnitIsInvalidException),
            1,
            MileageUnit.Kilometers.ToString().ToLower());
        Add(
            typeof(MileageUnitIsInvalidException),
            1,
            "Meters");
    }
}
