namespace Homework7.task1.Services;

public static class StringMethods
{
    public static string Reverse(string text)
    {
        ArgumentNullException.ThrowIfNull(text);

        char[] characters = text.ToCharArray();
        Array.Reverse(characters);

        return new string(characters);
    }
}