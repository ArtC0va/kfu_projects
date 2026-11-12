namespace Homework7.task1.Models;

public class Song
{
    private string _name = string.Empty;
    private string _author = string.Empty;
    private Song? _prev;

    public Song(string name, string author)
    {
        SetName(name);
        SetAuthor(author);
    }

    public void SetName(string name)
    {
        if (string.IsNullOrWhiteSpace(name))
        {
            throw new ArgumentException(
                "Name cannot be empty.", 
                nameof(name));
        }

        _name = name.Trim();
    }

    public void SetAuthor(string author)
    {
        if (string.IsNullOrWhiteSpace(author))
        {
            throw new ArgumentException(
                "Author cannot be empty.", 
                nameof(author));
        }

        _author = author.Trim();
    }

    public void SetPrev(Song? prev)
    {
        if (ReferenceEquals(prev, this))
        {
            throw new ArgumentException(
                "A song cannot precede itself.", 
                nameof(prev));
        }

        _prev = prev;
    }

    public string GetName()
    {
        return _name;
    }

    public string GetAuthor()
    {
        return _author;
    }

    public Song? GetPrev()
    {
        return _prev;
    }

    public string Title()
    {
        return $"{_name} - {_author}";
    }

    public void Print()
    {
        Console.WriteLine($"{Title()} (previous: {_prev?.Title() ?? "none"})");
    }

    public override bool Equals(object? obj)
    {
        if (ReferenceEquals(this, obj))
        {
            return true;
        }

        if (obj is not Song other)
        {
            return false;
        }

        return string.Equals(_name, other._name, StringComparison.OrdinalIgnoreCase)
            && string.Equals(_author, other._author, StringComparison.OrdinalIgnoreCase);
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(
            StringComparer.OrdinalIgnoreCase.GetHashCode(_name),
            StringComparer.OrdinalIgnoreCase.GetHashCode(_author));
    }
}