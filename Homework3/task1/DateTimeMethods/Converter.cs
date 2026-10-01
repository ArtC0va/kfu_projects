namespace Homework3.DateTimeMethods;

public static class DayOfYearConverter
{
    public const int ReferenceYear = 2023;

    public static bool IsLeapYear(int year)
    {
        return year % 400 == 0 || (year % 4 == 0 && year % 100 != 0);
    }

    public static int GetDaysInYear(int year)
    {
        return IsLeapYear(year) ? 366 : 365;
    }

    public static DateTime ToDate(int year, int dayOfYear)
    {
        return new DateTime(year, 1, 1).AddDays(dayOfYear - 1);
    }

    public static DateTime ToDateChecked(int year, int dayOfYear)
    {
        int daysInYear = GetDaysInYear(year);

        if (dayOfYear < 1 || dayOfYear > daysInYear)
        {
            throw new ArgumentOutOfRangeException(
                nameof(dayOfYear), 
                $"Day number must be from 1 to {daysInYear}");
        }

        return ToDate(year, dayOfYear);
    }
}