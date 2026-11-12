using System.Globalization;

namespace Homework7.task1.Services;

public static class FormatMethods
{
    public static bool IsFormattable(object? value)
    {
        return value is IFormattable;
    }

    public static IFormattable? AsFormattable(object? value)
    {
        return value as IFormattable;
    }

    public static string? FormatWithInterface(object? value, string format)
    {
        return AsFormattable(value)?.ToString(format, CultureInfo.InvariantCulture);
    }

    public static object ParseToObject(string text)
    {
        if (int.TryParse(text, out int integer))
        {
            return integer;
        }

        if (double.TryParse(text, out double number))
        {
            return number;
        }

        if (DateTime.TryParse(text, out DateTime date))
        {
            return date;
        }

        return text;
    }
}