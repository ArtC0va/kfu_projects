namespace Homework5.Task1.Methods;

public static class FileMethods
{
    private const string VowelLetters = "aeiouy";

    private enum LetterKind
    {
        NotCounted = 0,
        Vowel,
        Consonant
    }
    public static (int, int) TypeLetterCount(char[] text)
    {
        int vowelLetterCount = 0;
        int consonantLettelCount = 0;

        for (int i = 0; i < text.Length; i++)
        {
            LetterKind kind = GetLetterKind(text[i]);

            if (kind == LetterKind.Vowel)
            {
                vowelLetterCount++;
            }
            else if (kind == LetterKind.Consonant)
            {
                consonantLettelCount++;
            }
        }

        return (vowelLetterCount, consonantLettelCount);
    }
    
    private static LetterKind GetLetterKind(char symbol)
    {
        if (!char.IsLetter(symbol))
        {
            return LetterKind.NotCounted;
        }

        char letter = char.ToLowerInvariant(symbol);

        if (VowelLetters.Contains(letter))
        {
            return LetterKind.Vowel;
        }

        return LetterKind.Consonant;
    }

    public static (int, int) TypeLetterCount(List<char> text)
    {
        int vowelLetterCount = 0;
        int consonantLettelCount = 0;

        foreach (char symbol in text)
        {
            LetterKind kind = GetLetterKind(symbol);

            if (kind == LetterKind.Vowel)
            {
                vowelLetterCount++;
            }
            else if (kind == LetterKind.Consonant)
            {
                consonantLettelCount++;
            }
        }

        return (vowelLetterCount, consonantLettelCount);
    }
}