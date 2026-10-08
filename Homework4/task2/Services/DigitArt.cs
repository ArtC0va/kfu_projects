namespace Homework4.Task2.Services;

public static class DigitArt
{
    public const int MinDigit = 0;
    public const int MaxDigit = 9;

    public const int ErrorDisplay = 3000;
    public const string ExitCommand = "exit";
    public const string ExitCommandRu = "закрыть";
    private static readonly string[][] Patterns =
    {
        new[] { "###", "# #", "# #", "# #", "###" }, // 0
        new[] { " # ", "## ", " # ", " # ", "###" }, // 1
        new[] { "###", "  #", "###", "#  ", "###" }, // 2
        new[] { "###", "  #", "###", "  #", "###" }, // 3
        new[] { "# #", "# #", "###", "  #", "  #" }, // 4
        new[] { "###", "#  ", "###", "  #", "###" }, // 5
        new[] { "###", "#  ", "###", "# #", "###" }, // 6
        new[] { "###", "  #", "  #", "  #", "  #" }, // 7
        new[] { "###", "# #", "###", "# #", "###" }, // 8
        new[] { "###", "# #", "###", "  #", "###" }  // 9
    };

    public static string[] GetPattern(int digit)
    {
        if (digit < MinDigit || digit > MaxDigit)
        {
            throw new ArgumentOutOfRangeException(nameof(digit), "Digit must be from 0 to 9.");
        }

        return Patterns[digit];
    }

    public static bool IsExitCommand(string input)
    {
        return string.Equals(input, ExitCommand, StringComparison.OrdinalIgnoreCase)
            || string.Equals(input, ExitCommandRu, StringComparison.OrdinalIgnoreCase);
    }

    public static void HandleDigitInput(string input)
    {
        if (!int.TryParse(input, out int number))
        {
            throw new FormatException($"'{input}' is not a number.");
        }

        if (number < DigitArt.MinDigit || number > DigitArt.MaxDigit)
        {
            ShowRedError($"Error: {number} is not a digit. Enter a number from 0 to 9.");
            return;
        }

        foreach (string line in DigitArt.GetPattern(number))
        {
            Console.WriteLine(line);
        }
    }

    public static void ShowRedError(string message)
    {
        Console.BackgroundColor = ConsoleColor.Red;
        Console.ForegroundColor = ConsoleColor.White;
        Console.Clear();
        Console.WriteLine(message);

        Thread.Sleep(ErrorDisplay);

        Console.ResetColor();
        Console.Clear();
    }
}