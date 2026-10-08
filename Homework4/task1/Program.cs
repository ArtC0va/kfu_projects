using Homework4.Methods;
using GeneralMethods;

namespace Homework4
{
    public static class Program
    {
        static void Main()
        {
            //Тумаков
            Task1();
            Task2();
            Task3();
            Task4();
            Hometask1();
            Hometask2();
        }

        private static void Task1()
        {
            int numT11 = InputMethods.ReadValue<int>(
                "Enter first number",
                int.TryParse,
                errorMessage: "Number value must be an intager ");
            
            int numT12 = InputMethods.ReadValue<int>(
                "Enter second number",
                int.TryParse,
                errorMessage: "Number value must be an intager ");

            int maxNum = MainMethods.FindMax(numT11, numT12);

            Console.WriteLine($"Maximum number - {maxNum}");
        }


        private static void Task2()
        {
            var parameter1 = InputMethods.ReadValue<string>(
                "Enter first parameter",
                (string? s, out string v) =>
                {
                    v = s ?? string.Empty;
                    return true;
                });

            var parameter2 = InputMethods.ReadValue<string>(
                "Enter second parameter",
                (string? s, out string v) =>
                {
                    v = s ?? string.Empty;
                    return true;
                });    

            (var newPar1, var newPar2) = MainMethods.Swap(parameter1, parameter2);

            Console.WriteLine($"Result: {newPar1}, {newPar2}");
        }

        private static void Task3()
        {
            int numT3 = InputMethods.ReadValue<int>(
                "Enter a number to get its factorial",
                int.TryParse,
                errorMessage: "The number must be a natural");

            if (MainMethods.TryFactorial(numT3, out long result))
            {
                Console.WriteLine($"{numT3}! - {result}");
            }
            else
            {
                Console.WriteLine($"Overflow");
            }

        }

        private static void Task4()
        {
            int numT4 = InputMethods.ReadValue<int>(
                "Enter a number to get its factorial",
                int.TryParse,
                errorMessage: "The number must be a natural");

            try
            {
                Console.WriteLine($"{numT4}! - {MainMethods.FactorialRecursive(numT4)}");
            }
            catch (OverflowException)
            {
                Console.WriteLine($"Overflow");
            }
        }

        private static void Hometask1()
        {
            int numH11 = InputMethods.ReadValue<int>(
                "Enter first natural number",
                int.TryParse,
                errorMessage: "The number must be a natural");

            int numH12 = InputMethods.ReadValue<int>(
                "Enter second natural number",
                int.TryParse,
                errorMessage: "The number must be a natural");

            int numH13 = InputMethods.ReadValue<int>(
                "Enter third natural number",
                int.TryParse,
                errorMessage: "The number must be a natural");

            Console.WriteLine($"GCD({numH11}, {numH12}) - {MainMethods.GCD(numH11, numH12)}");

            Console.WriteLine($"GCD({numH11}, {numH12}, {numH13}) - {MainMethods.GCD(numH11, numH12, numH13)}");
        }

        private static void Hometask2()
        {
            int fnum = InputMethods.ReadValue<int>(
                "Enter first natural number",
                int.TryParse,
                errorMessage: "The number must be a natural");

            Console.WriteLine($"F({fnum}) - {MainMethods.FNum(fnum)}");
        }

    }
}