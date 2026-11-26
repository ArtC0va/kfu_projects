using Homework9.task1.Interfaces;
using Homework9.task1.Models;

namespace Homework9.task1.Services;

public class ACipher : ICipher
{
    public string Encode(string text)
    {
        return Shift(text, 1);
    }

    public string Decode(string text)
    {
        return Shift(text, -1);
    }

    private static string Shift(string text, int step)
    {
        char[] result = new char[text.Length];

        for (int i = 0; i < text.Length; i++)
        {
            string? alphabet = RussianAlphabet.GetAlphabetOf(text[i]);

            if (alphabet == null)
            {
                result[i] = text[i];
                continue;
            }

            int index = alphabet.IndexOf(text[i]);
            int newIndex = (index + step + alphabet.Length) % alphabet.Length;
            result[i] = alphabet[newIndex];
        }

        return new string(result);
    }
}