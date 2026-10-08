using Homework4.Task2.Enums;

namespace Homework4.Task2.Models;

public struct Grandpa
{
    public string Name { get; set; }
    public GrumpinessLevel Level { get; set; }
    public string[] Phrases { get; set; }
    public int BruiseCount { get; set; }

    public Grandpa(string name, GrumpinessLevel level, string[] phrases)
    {
        Name = name;
        Level = level;
        Phrases = phrases;
        BruiseCount = 0;
    }
    public static int CountBruises(ref Grandpa grandpa, params string[] badWords)
    {
        int newBruises = 0;

        foreach (string word in badWords.Distinct(StringComparer.OrdinalIgnoreCase))
        {
            if (string.IsNullOrWhiteSpace(word))
            {
                continue;
            }

            if (ContainsWord(grandpa.Phrases, word))
            {
                newBruises++;
            }
        }

        grandpa.BruiseCount += newBruises;
        return newBruises;
    }

    private static bool ContainsWord(string[] phrases, string word)
    {
        foreach (string phrase in phrases)
        {
            if (phrase.Contains(word, StringComparison.OrdinalIgnoreCase))
            {
                return true;
            }
        }

        return false;
    }

    public override string ToString()
    {
        return $"{Name}, phrases: {Phrases.Length}, bruises: {BruiseCount}";
    }
}