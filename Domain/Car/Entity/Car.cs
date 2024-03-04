using Domain.Car.ValueObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Car.Entity;

internal class Car
{
    private CarPlate Plate { get; }

    public Car(CarPlate plate)
    {
        Plate = plate;
    }
}
