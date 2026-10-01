namespace Homework3.Enums;

public static class Days
{
    public static string GetWeekDay(WeekDay day)
    {
        return day switch
        {
            WeekDay.Monday => "Monday",
            WeekDay.Tuesday => "Tuesday",
            WeekDay.Wednesday => "Wednesday",
            WeekDay.Thursday => "Thursday",
            WeekDay.Friday => "Friday",
            WeekDay.Saturday => "Saturday",
            WeekDay.Sunday => "Sunday",
            _ => throw new ArgumentOutOfRangeException(nameof(day))
        };
    }
}