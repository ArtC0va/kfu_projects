namespace Homework6.task2.Models;

public abstract class Part
{
    public const string UnknownManufacturer = "Unknown";

    private string _name = string.Empty;
    private decimal _price;

    public string Article { get; }

    public string Manufacturer { get;}

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

    public decimal Price
    {
        get => _price;
        set
        {
            if (value <= 0)
            {
                throw new ArgumentOutOfRangeException(
                    nameof(value), 
                    "Price must be positive.");
            }

            _price = value;
        }
    }

    public int Quantity { get; private set; }

    protected Part(string article, string name, string manufacturer, decimal price, int quantity)
    {
        if (string.IsNullOrWhiteSpace(article))
        {
            throw new ArgumentException(
                "Article cannot be empty.", 
                nameof(article));
        }

        if (quantity < 0)
        {
            throw new ArgumentOutOfRangeException(
                nameof(quantity), 
                "Quantity cannot be negative.");
        }

        Article = article.Trim();
        Manufacturer = string.IsNullOrWhiteSpace(manufacturer) 
            ? UnknownManufacturer : manufacturer.Trim();
        Name = name;
        Price = price;
        Quantity = quantity;
    }

    public abstract string GetCategory();

    public abstract string GetSpecifications();

    public virtual int GetWarrantyMonths()
    {
        return 12;
    }

    public bool IsInStock()
    {
        return Quantity > 0;
    }

    public void Restock(int amount)
    {
        if (amount <= 0)
        {
            throw new ArgumentOutOfRangeException(
                nameof(amount), 
                "Amount must be positive.");
        }

        Quantity += amount;
    }

    public bool Sell(int amount)
    {
        if (amount <= 0 || amount > Quantity)
        {
            return false;
        }

        Quantity -= amount;
        return true;
    }

    public void ApplyDiscount(decimal percent)
    {
        if (percent <= 0 || percent >= 100)
        {
            throw new ArgumentOutOfRangeException(
                nameof(percent), 
                "Discount must be between 0 and 100 percent.");
        }

        Price = Math.Round(Price * (100 - percent) / 100, 2);
    }

    public decimal GetTotalValue()
    {
        return Price * Quantity;
    }

    public override string ToString()
    {
        return $"{Article} {Name} ({Manufacturer}): {Price:F2}, in stock: {Quantity}";
    }
}