namespace GeneralMethods;

public static class InputMethods
{
    public delegate bool TryParse<T>(string? input, out T value);

    public static T ReadValue<T>(
        string message,
        TryParse<T> tryParse,
        Func<T, bool>? isValid = null,
        string errorMessage = "Invalid input, please try again.")
    {
        T value = default!;
        bool isInputCorrect = false;

        while (!isInputCorrect)
        {
            Console.WriteLine(message);
            string? input = Console.ReadLine();

            if (input == null)
            {
                throw new InvalidOperationException("Input stream was closed.");
            }

            isInputCorrect = tryParse(input, out value) && (isValid?.Invoke(value) ?? true);

            if (!isInputCorrect)
            {
                Console.WriteLine(errorMessage);
            }
        }

        return value;
    }

    public static string ReadString(string prompt, string errorMessage = "Value cannot be empty.")
    {
        return ReadValue<string>(prompt, TryParseNonEmpty, null, errorMessage);
    }

    private static bool TryParseNonEmpty(string? input, out string value)
    {
        value = input?.Trim() ?? string.Empty;
        return value.Length > 0;
    }

    public static bool TryParseIntArray(string? input, out int[] values)
    {
        values = Array.Empty<int>();
        if (string.IsNullOrWhiteSpace(input))
        {
            return false;
        }

        string[] parts = input.Split(new[] { ' ', ','}, StringSplitOptions.RemoveEmptyEntries);
        int[] parsed = new int[parts.Length];

        for (int i = 0; i < parts.Length; i++)
        {
            if (!int.TryParse(parts[i], out parsed[i]))
            {
                return false;
            }
        }

        values = parsed;
        return parsed.Length > 0;
    }
}
