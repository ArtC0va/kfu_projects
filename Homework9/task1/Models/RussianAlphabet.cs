namespace Homework9.task1.Models;

public static class RussianAlphabet
{
    public const string Lower = "абвгдеёжзийклмнопрстуфхцчшщъыьэюя";
    public const string Upper = "АБВГДЕЁЖЗИЙКЛМНОПРСТУФХЦЧШЩЪЫЬЭЮЯ";

    public static string? GetAlphabetOf(char symbol)
    {
        if (Lower.Contains(symbol))
        {
            return Lower;
        }

        if (Upper.Contains(symbol))
        {
            return Upper;
        }

        return null;
    }
}