using Homework9.task1.Interfaces;
using Homework9.task1.Models;

namespace Homework9.task1.Services;

public class BCipher : ICipher
{
    public string Encode(string text)
    {
        return Mirror(text);
    }

    public string Decode(string text)
    {
        return Mirror(text);
    }

    private static string Mirror(string text)
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
            result[i] = alphabet[alphabet.Length - 1 - index];
        }

        return new string(result);
    }
}