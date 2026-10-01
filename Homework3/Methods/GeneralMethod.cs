namespace Methods;

public static class InputMethods
{
    public delegate bool TryParse<T>(string? input, out T value);

    public static T ReadValue<T>(
        string? prompt,
        TryParse<T> tryParse,
        Func<T, bool>? isValid = null,
        string errorMessage = "Invalid input, please try again"
    )
    {
        while (true)
        {
            Console.WriteLine(prompt);
            string? input = Console.ReadLine()
                ?? throw new InvalidOperationException("Input stream was closed");

            if (tryParse(input, out T value) && (isValid?.Invoke(value) ?? true))
            {
                return value;
            }

            Console.WriteLine(errorMessage);
        }
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
}
