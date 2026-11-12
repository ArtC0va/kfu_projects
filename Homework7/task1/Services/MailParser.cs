namespace Homework7.task1.Services;

public class MailParser
{
    private const char Separator = '#';

    public void SearchMail(ref string s)
    {
        int separatorIndex = s.IndexOf(Separator);

        if (separatorIndex < 0)
        {
            s = string.Empty;
            return;
        }

        string candidate = s.Substring(separatorIndex + 1).Trim();
        s = IsPlausibleEmail(candidate) ? candidate : string.Empty;
    }

    private static bool IsPlausibleEmail(string text)
    {
        if (text.Length == 0 || text.Contains(' '))
        {
            return false;
        }

        int atIndex = text.IndexOf('@');

        if (atIndex <= 0 || atIndex != text.LastIndexOf('@'))
        {
            return false;
        }

        string domain = text.Substring(atIndex + 1);
        int dotIndex = domain.IndexOf('.');

        return dotIndex > 0 && !domain.EndsWith('.');
    }
}