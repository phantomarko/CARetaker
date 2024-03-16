using Domain.Vehicles.Exceptions;
using System.Text.RegularExpressions;

namespace Domain.Vehicles;

public sealed record CarPlate
{
    private const string EuropeFormat = "^H{0,1}\\d{4}[A-Z]{3}$";
    private const string ProvinceFormat = "^[A-Z]{1,2}\\d{4}[A-Z]{1,2}$";
    private static string[] ValidFormats => [EuropeFormat, ProvinceFormat];

    private CarPlate(string value) => Value = value;

    public string Value { get; init; }

    public static CarPlate Create(string value)
    {
        if (
            string.IsNullOrEmpty(value)
            || !ValidFormats.Any(format => Regex.IsMatch(value, format)))
        {
            throw new CarPlateFormatIsInvalidException();
        }

        return new CarPlate(value);
    }
}
