using Domain.Vehicles.Exceptions;
using Domain.Vehicles;

namespace Tests.Domain.Unit.Vehicles;

public class RegistrationPlateTest
{
    [Theory]
    [ClassData(typeof(RegistrationPlateCreateValidData))]
    public void Create_Should_ReturnPlate(string value)
    {
        var plate = RegistrationPlate.Create(value);

        Assert.Equal(plate.Value, value.ToUpper());
    }

    [Theory]
    [ClassData(typeof(RegistrationPlateCreateInvalidData))]
    public void Create_Should_ThrowException(Type expectedException, string value)
    {
        Assert.Throws(expectedException, () => RegistrationPlate.Create(value));
    }
}

public class RegistrationPlateCreateValidData : TheoryData<string>
{
    public RegistrationPlateCreateValidData()
    {
        Add("A");
        Add("1");
        Add("TH3PH4NT0M");
        Add("lower");
        Add(new string('A', RegistrationPlate.MaximumLength));
        Add("7465BZD");
        Add("H0000BBB");
        Add("MA0288AC");
        Add("MYKSM704");
        Add("AA-111-AA");
        Add("BD51SMR");
    }
}

public class RegistrationPlateCreateInvalidData : TheoryData<Type, string>
{
    public RegistrationPlateCreateInvalidData()
    {
        Add(typeof(RegistrationPlateIsEmptyException), "");
        Add(typeof(RegistrationPlateIsEmptyException), new string(' ', RegistrationPlate.MaximumLength));
        Add(typeof(RegistrationPlateLengthIsInvalidException), new string('A', RegistrationPlate.MaximumLength + 1));
        Add(typeof(RegistrationPlateFormatIsInvalidException), "7465 BZD");
        Add(typeof(RegistrationPlateFormatIsInvalidException), "7465_BZD");
        Add(typeof(RegistrationPlateFormatIsInvalidException), "$M0N3Y$");
    }
}
