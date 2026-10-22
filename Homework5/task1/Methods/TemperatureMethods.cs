namespace Homework5.Task1.Methods;

public static class TemperatureMethods
{
    public const int MonthsCount = 12;
    public const int DaysInMonth = 30;

    public static string[] MonthNames =
    {
        "January", "February", "March", "April", "May", "June",
        "July", "August", "September", "October", "November", "December"
    };

    public static int[,] GenerateTemperatures(int minValue, int maxValue)
    {
        int[,] temperature = new int[MonthsCount, DaysInMonth];

        for (int month = 0; month < MonthsCount; month++)
        {
            for (int day = 0; day < DaysInMonth; day++)
            {
                temperature[month, day] = Random.Shared.Next(minValue, maxValue);
            }
        }

        return temperature;
    }

    public static double[] CalculateMonthlyAverages(int[,] temperature)
    {
        int months = temperature.GetLength(0);
        int days = temperature.GetLength(1);
        double[] averages = new double[months];

        for (int month = 0; month < months; month++)
        {
            int sum = 0;

            for (int day = 0; day < days; day++)
            {
                sum += temperature[month, day];
            }

            averages[month] = (double)sum / days;
        }

        return averages;
    }

    public static Dictionary<string, int[]> GenerateTemperatureDictionary(int minValue, int maxValueExclusive)
    {
        Dictionary<string, int[]> temperatures = new Dictionary<string, int[]>();

        foreach (string month in MonthNames)
        {
            int[] days = new int[DaysInMonth];

            for (int day = 0; day < days.Length; day++)
            {
                days[day] = Random.Shared.Next(minValue, maxValueExclusive);
            }

            temperatures.Add(month, days);
        }

        return temperatures;
    }

    public static Dictionary<string, double> CalculateAveragesByMonth(Dictionary<string, int[]> temperatures)
    {
        Dictionary<string, double> averages = new Dictionary<string, double>();

        foreach (KeyValuePair<string, int[]> pair in temperatures)
        {
            int sum = 0;

            foreach (int value in pair.Value)
            {
                sum += value;
            }

            averages.Add(pair.Key, (double)sum / pair.Value.Length);
        }

        return averages;
    }

    public static List<KeyValuePair<string, double>> SortByValue(Dictionary<string, double> averages)
    {
        List<KeyValuePair<string, double>> pairs = new List<KeyValuePair<string, double>>(averages);
        pairs.Sort((first, second) => first.Value.CompareTo(second.Value));
        return pairs;
    }
}