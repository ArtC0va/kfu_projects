using GeneralMethods;
using Homework4.Task2.Enums;
using Homework4.Task2.Models;
using Homework4.Task2.Services;

namespace Homework4.Task2
{
    public static class Program
    {
        private const int ArraySize = 5;
        private const int MinRandomValue = 1;
        private const int MaxRandomValue = 100;

        static void Main()
        {
            Task1();
            Task2();
            Task3();
            Task4();
        }

        private static void Task1()
        {
            int[] numbers = ArrayMethods.CreateRandomArray(ArraySize, MinRandomValue, MaxRandomValue);
            Console.WriteLine($"Array - {string.Join(", ", numbers)}");

            int firstValue = InputMethods.ReadValue<int>(
                "Enter the first number to swap",
                int.TryParse,
                value => Array.IndexOf(numbers, value) >= 0,
                "This number isn't in the array");
            
            int secondValue = InputMethods.ReadValue<int>(
                "Enter the second number to swap",
                int.TryParse,
                value => Array.IndexOf(numbers, value) >= 0,
                "This number isn't in the array");

            ArrayMethods.SwapValues(numbers, firstValue, secondValue);

            Console.WriteLine($"Result - {string.Join(", ", numbers)}");
        }

        private static void Task2()
        {
            int[] numbersT2 = InputMethods.ReadValue<int[]>(
                "Enter intergers",
                InputMethods.TryParseIntArray,
                errorMessage: "The array must not be empty");
            
            long product = 1;

            try
            {
                long sum = ArrayMethods.SumProductAverage(ref product, out double average, numbersT2);

                Console.WriteLine($"Sum - {sum}");
                Console.WriteLine($"Product - {product}");
                Console.WriteLine($"Average - {average}");
            }
            catch (OverflowException)
            {
                Console.WriteLine("Overflow");
            }

        }

        private static void Task3()
        {
            bool isExitRequested = false;

            while (!isExitRequested)
            {
                string input = InputMethods.ReadValue<string>(
                    "Enter a number",
                    (string? s, out string v) =>
                {
                    v = s ?? string.Empty;
                    return true;
                });

                if (DigitArt.IsExitCommand(input))
                {
                    isExitRequested = true;
                }
                else
                {
                    DigitArt.HandleDigitInput(input);
                }
            }
        }

        private static void Task4()
        {
            Grandpa[] grandpas = NewGrandpa.CreateGrandpas();
            int totalBruises = 0;

            for (int i = 0; i < grandpas.Length; i++)
            {
                int newBruises = Grandpa.CountBruises(ref grandpas[i], "гады", "балбесы", "тунеядцы");
                totalBruises += newBruises;

                Console.WriteLine($"{grandpas[i]}");
            }
        }
    }
}

