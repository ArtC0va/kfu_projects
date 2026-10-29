namespace Homework6.task2.Models;

public class EnginePart : Part
{
    private const double DefaultVolumeLiters = 1.6;
    private const int DefaultServiceIntervalKm = 15000;

    private double _engineVolumeLiters;

    public double EngineVolumeLiters
    {
        get => _engineVolumeLiters;
        set
        {
            if (value <= 0)
            {
                throw new ArgumentOutOfRangeException(
                    nameof(value), 
                    "Engine volume must be positive.");
            }

            _engineVolumeLiters = value;
        }
    }

    public int ServiceIntervalKm { get; }

    public EnginePart(
        string article,
        string name,
        string manufacturer,
        decimal price,
        int quantity,
        double engineVolumeLiters,
        int serviceIntervalKm)
        : base(article, name, manufacturer, price, quantity)
    {
        if (serviceIntervalKm <= 0)
        {
            throw new ArgumentOutOfRangeException(
                nameof(serviceIntervalKm), 
                "Service interval must be positive.");
        }

        EngineVolumeLiters = engineVolumeLiters;
        ServiceIntervalKm = serviceIntervalKm;
    }

    public EnginePart(string article, string name, decimal price, int quantity)
        : this(article, name, UnknownManufacturer, price, quantity, DefaultVolumeLiters, DefaultServiceIntervalKm) { }

    public override string GetCategory()
    {
        return "Engine";
    }

    public override string GetSpecifications()
    {
        return $"engine {EngineVolumeLiters:F1} L, service interval {ServiceIntervalKm} km";
    }

    public override int GetWarrantyMonths()
    {
        return 24;
    }

    public bool IsCompatibleWith(double engineVolumeLiters)
    {
        return Math.Abs(EngineVolumeLiters - engineVolumeLiters) < 0.0001;
    }

    public bool NeedsReplacement(int drivenKm)
    {
        return drivenKm >= ServiceIntervalKm;
    }
}