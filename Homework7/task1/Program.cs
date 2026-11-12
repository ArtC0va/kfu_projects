using GeneralMethods;
using Homework7.task1.Enums;
using Homework7.task1.Models;
using Homework7.task1.Services;

namespace Homework7.task1;

public class Program
{
    public static void Main()
    {
        Task1();
        Task2();
        Task3();
        Task4();
        Hometask1();
        Hometask2();
    }

    private static void Task1()
    {
        string[] roles = { "source account (money is taken from it)", "target account (money goes to it)" };
        AccountType[] accountTypes = Enum.GetValues<AccountType>();
        Bank[] accounts = new Bank[roles.Length];

        for (int i = 0; i < roles.Length; i++)
        {
            decimal balance = InputMethods.ReadValue<decimal>(
                $"Enter the balance of the {roles[i]}",
                decimal.TryParse,
                value => value >= 0,
                "Enter a number that is 0 or greater");

            Console.WriteLine($"Choose the type of the {roles[i]}:");

            for (int j = 0; j < accountTypes.Length; j++)
            {
                Console.WriteLine($"{j + 1} - {accountTypes[j]}");
            }

            int typeNumber = InputMethods.ReadValue<int>(
                "Enter the option number",
                int.TryParse,
                number => number >= 1 && number <= accountTypes.Length,
                $"Enter a number from 1 to {accountTypes.Length}");

            accounts[i] = new Bank(balance, accountTypes[typeNumber - 1]);
        }

        Bank source = accounts[0];
        Bank target = accounts[1];

        decimal amount = InputMethods.ReadValue<decimal>(
            "Enter the amount to transfer",
            decimal.TryParse,
            value => value > 0,
            "Enter a positive number");

        Console.WriteLine($"Before: {source} | {target}");

        if (target.TransferFrom(source, amount))
        {
            Console.WriteLine("Transfer done.");
        }
        else
        {
            Console.WriteLine("Transfer failed: not enough money on the source account.");
        }

        Console.WriteLine($"After:  {source} | {target}");
    }

    private static void Task2()
    {
        string[] samples = { "abc", "Привет", "a b c d", "madam", string.Empty };

        foreach (string sample in samples)
        {
            Console.WriteLine($"Test: \"{sample}\" -> \"{StringMethods.Reverse(sample)}\"");
        }

        Console.WriteLine("Enter a string");
        string text = Console.ReadLine() ?? string.Empty;

        Console.WriteLine($"Reversed: {StringMethods.Reverse(text)}");
    }

    private static void Task3()
    {
        const string UpperCaseSuffix = "_upper";

        string samplePath = Path.Combine(AppContext.BaseDirectory, "Data", "people.txt");
        Console.WriteLine($"A sample file you can use: {samplePath}");

        string path = InputMethods.ReadString("Enter the file name").Trim('"');

        try
        {
            string outputPath = FileMethods.BuildOutputPath(path, UpperCaseSuffix);

            if (FileMethods.TryConvertToUpperCase(path, outputPath))
            {
                Console.WriteLine($"Done. The upper-case copy is saved to \"{outputPath}\".");
            }
            else
            {
                Console.WriteLine($"The file \"{path}\" does not exist. Finishing this exercise.");
            }
        }
        catch (Exception err) when (err is IOException
                                       or UnauthorizedAccessException
                                       or ArgumentException
                                       or NotSupportedException)
        {
            Console.WriteLine($"File error: {err.Message}");
        }
    }

    private static void Task4()
    {
        Console.WriteLine("Enter a value (a number, a date or any text)");
        string text = Console.ReadLine() ?? string.Empty;
        object value = FormatMethods.ParseToObject(text);

        bool isFormattable = FormatMethods.IsFormattable(value);
        IFormattable? formattable = FormatMethods.AsFormattable(value);

        Console.WriteLine($"The value was recognised as {value.GetType().Name}.");
        Console.WriteLine($"Operator is: {(isFormattable ? "implements IFormattable" : "does not implement IFormattable")}");
        Console.WriteLine($"Operator as: {(formattable != null ? "got an IFormattable reference" : "got null")}");

        if (formattable == null)
        {
            return;
        }

        Console.WriteLine("Enter a format string (e.g. F2 for numbers, yyyy-MM-dd for dates)");
        string format = Console.ReadLine() ?? string.Empty;

        try
        {
            Console.WriteLine($"Formatted: {FormatMethods.FormatWithInterface(value, format)}");
        }
        catch (FormatException)
        {
            Console.WriteLine($"The format \"{format}\" is not valid for {value.GetType().Name}.");
        }
    }

    private static void Hometask1()
    {
        const string MailsFileName = "emails.txt";

        string samplePath = Path.Combine(AppContext.BaseDirectory, "Data", "people.txt");
        Console.WriteLine($"A sample file you can use: {samplePath}");

        string inputPath = InputMethods.ReadString("Enter the file name").Trim('"');

        if (!File.Exists(inputPath))
        {
            Console.WriteLine($"The file \"{inputPath}\" does not exist.");
            return;
        }

        try
        {
            string outputPath = FileMethods.BuildSiblingPath(inputPath, MailsFileName);
            int count = FileMethods.ExtractMails(inputPath, outputPath, out int skippedLines);

            Console.WriteLine($"E-mails found: {count}, skipped lines: {skippedLines}. Saved to \"{outputPath}\":");

            foreach (string mail in File.ReadAllLines(outputPath))
            {
                Console.WriteLine(mail);
            }
        }
        catch (Exception err) when (err is IOException
                                       or UnauthorizedAccessException
                                       or ArgumentException
                                       or NotSupportedException)
        {
            Console.WriteLine($"File error: {err.Message}");
        }
    }

    private static void Hometask2()
    {
        const int SongsCount = 4;

        List<Song> songs = new List<Song>();

        for (int i = 0; i < SongsCount; i++)
        {
            string name = InputMethods.ReadString($"Song {i + 1}: enter the name");
            string author = InputMethods.ReadString($"Song {i + 1}: enter the author");

            Song song = new Song(name, author);
            song.SetPrev(songs.Count > 0 ? songs[songs.Count - 1] : null);
            songs.Add(song);
        }

        Console.WriteLine("Songs:");

        foreach (Song song in songs)
        {
            song.Print();
        }

        bool isSame = songs[0].Equals(songs[1]);
        Console.WriteLine($"The first and the second songs are {(isSame ? "the same" : "different")}.");
    }
}