using SharedKernel.Measures;

namespace SharedKernel.Tests.Unit.Measures;

public class MileageTest
{
    [Theory]
    [ClassData(typeof(MileageCreateValidData))]
    public void Create_Should_ReturnMileage(int value, string unit)
    {
        var mileage = Mileage.Create(value, unit);

        Assert.Equal(value, mileage.Value);
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
        Add(0, MileageUnit.km.ToString());
        Add(1, MileageUnit.km.ToString());
        Add(288, MileageUnit.km.ToString());
        Add(0, MileageUnit.mi.ToString());
        Add(1, MileageUnit.mi.ToString());
        Add(666, MileageUnit.mi.ToString());
    }
}

public class MileageCreateInvalidData : TheoryData<Type, int, string>
{
    public MileageCreateInvalidData()
    {
        Add(
            typeof(MileageValueIsLessThanZeroException),
            -1,
            MileageUnit.km.ToString());
        Add(
            typeof(MileageUnitIsInvalidException),
            1,
            MileageUnit.km.ToString().ToUpper());
        Add(
            typeof(MileageUnitIsInvalidException),
            1,
            "m");
    }
}
