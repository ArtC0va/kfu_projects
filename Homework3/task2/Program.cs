using Methods;
using Homework3.Methods;
using Homework3.Enums;

namespace Homework3
{
    static class Program
    {
        private const string HelloKitty = "Hello Kitty";
        private const string BarbieDoll = "Barbie doll";

        static void Main()
        {
            Task1();
            Task2();
            Task3();
            Task4();
            Task5();
        }

        private static void Task1()
        {
            double[] numbers = NumberMethods.ReadNumbers();

            int violationIndex = NumberMethods.FindFirstViolation(numbers);

            if (violationIndex == NumberMethods.NotFound)
            {
                Console.WriteLine("The sequence is in ascending order");
            }
            else
            {
                Console.WriteLine("The sequence is NOT in ascending order");
                Console.WriteLine($"The first number of violation is {numbers[violationIndex]}");
            }

        }

        private static void Task2()
        {
            int cardValueNumber = InputMethods.ReadValue<int>(
            "Enter card value number",
            int.TryParse,
            errorMessage: "It cannot be the card value");

            try
            {
                Console.WriteLine($"Card {cardValueNumber} - {CardValue.GetCardName(cardValueNumber)}");
            }
            catch (ArgumentOutOfRangeException err)
            {
                Console.WriteLine($"Error: {err.Message}");
            }
        }

        private static void Task3()
        {
            Console.WriteLine("Enter occupation");
            string occupation = Console.ReadLine() ?? string.Empty;

            Console.WriteLine(DrinkVariant.GetDrink(occupation));
        }

        private static void Task4()
        {
            int weekNumber = InputMethods.ReadValue<int>(
                "Enter day number",
                int.TryParse,
                n => n is > 0 and < 8,
                "Number must be an integer from 1 to 7");

            WeekDay day = (WeekDay)weekNumber;
            Console.WriteLine($"Day {weekNumber} - {Days.GetWeekDay(day)}");
            
        }

        private static void Task5()
        {
            string[] toys = {HelloKitty, "Lego", BarbieDoll, "Teddy bear", HelloKitty, "Hot Wheels"};

            int dollsInBag = 0;
            foreach (string toy in toys)
            {
                if (toy == HelloKitty || toy == BarbieDoll)
                {
                    dollsInBag++;
                }
            }

            Console.WriteLine($"Dolls in the bag - {dollsInBag}");
        }
    }
}
