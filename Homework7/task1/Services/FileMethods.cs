namespace Homework7.task1.Services;

public static class FileMethods
{
    public static string BuildOutputPath(string inputPath, string suffix)
    {
        string fullPath = Path.GetFullPath(inputPath);
        string directory = Path.GetDirectoryName(fullPath) ?? string.Empty;
        string name = Path.GetFileNameWithoutExtension(fullPath);
        string extension = Path.GetExtension(fullPath);

        return Path.Combine(directory, $"{name}{suffix}{extension}");
    }

    public static string BuildSiblingPath(string inputPath, string fileName)
    {
        string directory = Path.GetDirectoryName(Path.GetFullPath(inputPath)) ?? string.Empty;
        return Path.Combine(directory, fileName);
    }

    public static bool TryConvertToUpperCase(string inputPath, string outputPath)
    {
        if (!File.Exists(inputPath))
        {
            return false;
        }

        EnsureDifferentPaths(inputPath, outputPath);

        using StreamReader reader = new StreamReader(inputPath);
        using StreamWriter writer = new StreamWriter(outputPath);

        string? line = reader.ReadLine();

        while (line != null)
        {
            writer.WriteLine(line.ToUpperInvariant());
            line = reader.ReadLine();
        }

        return true;
    }

    public static int ExtractMails(string inputPath, string outputPath, out int skippedLines)
    {
        EnsureDifferentPaths(inputPath, outputPath);

        MailParser parser = new MailParser();
        int written = 0;
        skippedLines = 0;

        using StreamReader reader = new StreamReader(inputPath);
        using StreamWriter writer = new StreamWriter(outputPath);

        string? line = reader.ReadLine();

        while (line != null)
        {
            if (!string.IsNullOrWhiteSpace(line))
            {
                string text = line;
                parser.SearchMail(ref text);

                if (text.Length == 0)
                {
                    skippedLines++;
                }
                else
                {
                    writer.WriteLine(text);
                    written++;
                }
            }

            line = reader.ReadLine();
        }

        return written;
    }

    private static void EnsureDifferentPaths(string inputPath, string outputPath)
    {
        bool isSame = string.Equals(
            Path.GetFullPath(inputPath),
            Path.GetFullPath(outputPath),
            StringComparison.OrdinalIgnoreCase);

        if (isSame)
        {
            throw new ArgumentException("Input and output files must be different.");
        }
    }
}