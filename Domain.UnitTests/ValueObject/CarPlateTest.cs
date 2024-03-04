using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.ValueObject;

namespace Domain.UnitTests.Entity;

[TestFixture]
internal class CarPlateTest
{
    [TestCaseSource(nameof(CreateCases))]
    public void CreateTest(string value)
    {
        CarPlate plate = new(value);

        Assert.That(plate.Value, Is.EqualTo(value));
    }

    public static object[] CreateCases =
    {
        new object[] { "7465BZD" }, // standard
        new object[] { "H7465BZD" }, // historic
        new object[] { "MA2888AZ" } // province
    };
}
