namespace Homework6.task2.Models;

public class BrakePart : Part
{
    private const int DefaultDiscDiameterMm = 280;

    private int _discDiameterMm;
    
    public int DiscDiameterMm
    {
        get => _discDiameterMm;
        set
        {
            if (value <= 0)
            {
                throw new ArgumentOutOfRangeException(
                    nameof(value),
                    "Diameter must be positive.");
            }

            _discDiameterMm = value;
        }
    }
    
    public bool IsVentilated { get; }

    public BrakePart(
        string article,
        string name,
        string manufacturer,
        decimal price,
        int quantity,
        int discDiameterMm,
        bool isVentilated)
        : base(article, name, manufacturer, price, quantity)
    {
        DiscDiameterMm = discDiameterMm;
        IsVentilated = isVentilated;
    }

    public BrakePart(string article, string name, decimal price, int quantity)
        : this(article, name, UnknownManufacturer, price, quantity, DefaultDiscDiameterMm, false) { }

    public override string GetCategory()
    {
        return "Brakes";
    }

    public override string GetSpecifications()
    {
        string type = IsVentilated ? "ventilated" : "solid";
        return $"disc {DiscDiameterMm} mm, {type}";
    }

    public override int GetWarrantyMonths()
    {
        return 18;
    }

    public bool IsSuitableForDiameter(int diameterMm)
    {
        return DiscDiameterMm == diameterMm;
    }

    public string GetEfficiencyRating()
    {
        return IsVentilated ? "High" : "Standard";
    }
}