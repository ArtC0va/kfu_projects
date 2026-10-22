using Homework5.Task1.Methods;
using GeneralMethods;

namespace Homework5.Task1
{
    public static class Program
    {
        private const int MinTemperature = -50;
        private const int MaxTemperature = 50;
        private const int MinMatrixSize = 1;
        private const int MaxMatrixSize = 10;
        private const int MinMatrixValue = -10;
        private const int MaxMatrixValue = 10;

        static void Main(string[] args)
        {
            string filePath = args.Length > 0 ? args[0] 
                : InputMethods.ReadString("Enter the path to a text file");
            
            Task1(filePath); //dotnet run --project Homework5/task1 -- Homework5/task1/Data/text.txt
            Task2();
            Task3();
            HomeTask1(filePath);
            //HomeTask2();
            HomeTask3();
        
        
        }

        private static bool TryReadText(string path, out string text)
        {
            try
            {
                text = File.ReadAllText(path);
                return true;
            }
            catch (Exception ex) when (ex is IOException
                                        or UnauthorizedAccessException
                                        or ArgumentException
                                        or NotSupportedException)
            {
                Console.WriteLine($"Cannot read the file: {ex.Message}");
                text = string.Empty;
                return false;
            }
        }

        private static void Task1(string filePath)
        {
            if (!TryReadText(filePath, out string text))
            {
                return;
            }

            char[] characters = text.ToCharArray();
            (int vowels, int consonants) = FileMethods.TypeLetterCount(characters);

            Console.WriteLine($"File \"{filePath}\": vowels = {vowels}, consonants = {consonants}");
        }

        private static bool IsValidSize(int size)
        {
            return size is >= MinMatrixSize and <= MaxMatrixSize;
        }

        private static (int LeftRows, int LeftColumns, int RightRows, int RightColumns) ReadMatrixSizes()
        {
            string errorMessage = $"Enter an integer from {MinMatrixSize} to {MaxMatrixSize}";

            Console.WriteLine("Multiplication works only if columns of the first matrix = rows of the second one.");
            int leftRows = InputMethods.ReadValue<int>(
                "Rows of the first matrix",
                int.TryParse,
                IsValidSize, 
                errorMessage);
            int leftColumns = InputMethods.ReadValue<int>(
                "Columns of the first matrix", 
                int.TryParse,
                IsValidSize, 
                errorMessage);
            int rightRows = InputMethods.ReadValue<int>(
                "Rows of the second matrix", 
                int.TryParse,
                IsValidSize, 
                errorMessage);
            int rightColumns = InputMethods.ReadValue<int>(
                "Columns of the second matrix", 
                int.TryParse,
                IsValidSize, 
                errorMessage);

            return (leftRows, leftColumns, rightRows, rightColumns);
        }

        private static void Task2()
        {
            (int LeftRows, int LeftColumns, int RightRows, int RightColumns) sizes = ReadMatrixSizes();

            int[,] left = MatrixMethods.CreateRandom(sizes.LeftRows, sizes.LeftColumns, MinMatrixValue, MaxMatrixValue);
            int[,] right = MatrixMethods.CreateRandom(sizes.RightRows, sizes.RightColumns, MinMatrixValue, MaxMatrixValue);

            Console.WriteLine("First matrix:");
            MatrixMethods.Print(left);
            Console.WriteLine("Second matrix:");
            MatrixMethods.Print(right);

            try
            {
                int[,] product = MatrixMethods.Multiply(left, right);
                Console.WriteLine("Product:");
                MatrixMethods.Print(product);
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }

        private static void Task3()
        {
            int[,] constantMonths = new int[TemperatureMethods.MonthsCount, TemperatureMethods.DaysInMonth];

            for (int month = 0; month < TemperatureMethods.MonthsCount; month++)
            {
                for (int day = 0; day < TemperatureMethods.DaysInMonth; day++)
                {
                    constantMonths[month, day] = month;
                }
            }

            int[,] temperature = TemperatureMethods.GenerateTemperatures(MinTemperature, MaxTemperature);
            double[] averages = TemperatureMethods.CalculateMonthlyAverages(temperature);

            Console.WriteLine("Average temperature by month:");

            for (int month = 0; month < averages.Length; month++)
            {
                Console.WriteLine($"{TemperatureMethods.MonthNames[month],-10} {averages[month],6:F1}");
            }

            double[] sortedAverages = (double[])averages.Clone();
            Array.Sort(sortedAverages);

            Console.WriteLine("Averages sorted ascending:");
            Console.WriteLine(string.Join("  ", Array.ConvertAll(sortedAverages, value => value.ToString("F1"))));
        }

        private static void HomeTask1(string filePath)
        {
            if (!TryReadText(filePath, out string text))
            {
                return;
            }

            List<char> characters = new List<char>(text);
            (int vowels, int consonants) = FileMethods.TypeLetterCount(characters);

            Console.WriteLine($"File \"{filePath}\": vowels = {vowels}, consonants = {consonants}");
        }

        private static void HomeTask2()
        {
            
        }

        private static void HomeTask3()
        {
            Dictionary<string, int[]> sample = new Dictionary<string, int[]>
            {
                ["January"] = new[] { 10, 20 },
                ["February"] = new[] { 5, 5 }
            };

            Dictionary<string, int[]> temperatures = TemperatureMethods.GenerateTemperatureDictionary(MinTemperature, MaxTemperature);
            Dictionary<string, double> averages = TemperatureMethods.CalculateAveragesByMonth(temperatures);

            Console.WriteLine("Average temperature by month:");

            foreach (string month in TemperatureMethods.MonthNames)
            {
                Console.WriteLine($"{month,-10} {averages[month],6:F1}");
            }

            List<KeyValuePair<string, double>> sorted = TemperatureMethods.SortByValue(averages);

            Console.WriteLine("Sorted by average temperature (ascending):");

            foreach (KeyValuePair<string, double> pair in sorted)
            {
                Console.WriteLine($"{pair.Key,-10} {pair.Value,6:F1}");
            }
        }
    }
}