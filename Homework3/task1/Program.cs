using Methods;
using Homework3.DateTimeMethods;

namespace Homework3
{
    static class Program
    {
        static void Main()
        {
            // Тумаков
            Task41();
            Task42();
            Hometask41();
        }

        private static void Task41()
        {
            int dayOfYear = InputMethods.ReadValue<int>(
                "Enter day number from 1 to 365",
                int.TryParse,
                d => d is > 0 and < 366,
                "Day number must be from 1 to 365");

            DateTime date = DayOfYearConverter.ToDate(DayOfYearConverter.ReferenceYear, dayOfYear);
            Console.WriteLine($"Day {dayOfYear} corresponds to: {FormatDate(date)}");
        }

        private static void Task42()
        {
            int dayOfYear = InputMethods.ReadValue<int>(
                "Enter day number from 1 to 365",
                int.TryParse,
                errorMessage: "This isn't an integer");
            
            try
            {
                DateTime date = DayOfYearConverter.ToDateChecked(DayOfYearConverter.ReferenceYear, dayOfYear);                
                Console.WriteLine($"Day {dayOfYear} corresponds to: {FormatDate(date)}");
            }
            catch (ArgumentOutOfRangeException err)
            {
                Console.WriteLine($"Error: {err.Message}");
            }
        }

        private static void Hometask41()
        {
            int year = InputMethods.ReadValue<int>(
                "Enter year", 
                int.TryParse,
                y => y is > 0 and < 5000,
                "Year must be an integer from 1 to 4999");
            
            var leapInfo = DayOfYearConverter.IsLeapYear(year) ? "leap" : "not leap";
            Console.WriteLine($"{year} is a {leapInfo} year");

            int dayOfYear = InputMethods.ReadValue<int>(
                "Enter day number",
                int.TryParse, 
                errorMessage: "This isn't an intager");
            
            try
            {
                DateTime date = DayOfYearConverter.ToDateChecked(year, dayOfYear);
                Console.WriteLine($"Day {dayOfYear} of {year} corresponds to: {FormatDate(date)}");
            }
            catch (ArgumentOutOfRangeException err)
            {
                Console.WriteLine($"Error: {err.Message}");
            }
        }

        private static string FormatDate(DateTime date)
        {
            return date.ToString("d MMMM");
        }
    }
}