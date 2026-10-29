namespace Homework6.task2.Models;

public class Catalog
{
    private readonly List<Part> _parts = new List<Part>();
    private string _name = string.Empty;

    public string Name
    {
        get 
        {
            return _name;
        }
        set
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException(
                    "Name cannot be empty.", 
                    nameof(value));
            }

            _name = value.Trim();
        }
    }

    public int Count => _parts.Count;

    public IReadOnlyList<Part> Parts => _parts;

    public decimal TotalValue
    {
        get
        {
            decimal total = 0;

            foreach (Part part in _parts)
            {
                total += part.GetTotalValue();
            }

            return total;
        }
    }

    public Catalog(string name)
    {
        Name = name;
    }

    public bool Add(Part part)
    {
        ArgumentNullException.ThrowIfNull(part);

        if (FindByArticle(part.Article) != null)
        {
            return false;
        }

        _parts.Add(part);
        return true;
    }

    public bool Remove(string article)
    {
        Part? part = FindByArticle(article);

        if (part == null)
        {
            return false;
        }

        _parts.Remove(part);
        return true;
    }

    public Part? FindByArticle(string article)
    {
        foreach (Part part in _parts)
        {
            if (string.Equals(part.Article, article.Trim(), StringComparison.OrdinalIgnoreCase))
            {
                return part;
            }
        }

        return null;
    }

    public List<Part> SearchByName(string text)
    {
        List<Part> found = new List<Part>();

        foreach (Part part in _parts)
        {
            if (part.Name.Contains(text.Trim(), StringComparison.OrdinalIgnoreCase))
            {
                found.Add(part);
            }
        }

        return found;
    }

    public List<Part> GetByCategory(string category)
    {
        List<Part> found = new List<Part>();

        foreach (Part part in _parts)
        {
            if (string.Equals(part.GetCategory(), category, StringComparison.OrdinalIgnoreCase))
            {
                found.Add(part);
            }
        }

        return found;
    }

    public List<Part> GetOutOfStock()
    {
        List<Part> found = new List<Part>();

        foreach (Part part in _parts)
        {
            if (!part.IsInStock())
            {
                found.Add(part);
            }
        }

        return found;
    }

    public void SortByPrice()
    {
        _parts.Sort((first, second) => first.Price.CompareTo(second.Price));
    }
}