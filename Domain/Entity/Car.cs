using Domain.ValueObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entity;

public class Car
{
    public CarPlate Plate { get; }

    public Car(CarPlate plate)
    {
        Plate = plate;
    }
}
