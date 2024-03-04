using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.ValueObject;

public class CarPlate
{
    public string Value { get; init; }

    public CarPlate(string value)
    {
        Value = value;
    }
}
