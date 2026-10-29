namespace Homework6.task2.Models;

public class ElectricalPart : Part
{
    private const int DefaultVoltageVolts = 12;
    private const int DefaultCurrentAmps = 10;

    private int _voltageVolts;

    public int VoltageVolts
    {
        get => _voltageVolts;
        set
        {
            if (value <= 0)
            {
                throw new ArgumentOutOfRangeException(
                    nameof(value), 
                    "Voltage must be positive.");
            }

            _voltageVolts = value;
        }
    }

    public int CurrentAmps { get; }

    public ElectricalPart(
        string article,
        string name,
        string manufacturer,
        decimal price,
        int quantity,
        int voltageVolts,
        int currentAmps)
        : base(article, name, manufacturer, price, quantity)
    {
        if (currentAmps <= 0)
        {
            throw new ArgumentOutOfRangeException(
                nameof(currentAmps), 
                "Current must be positive.");
        }

        VoltageVolts = voltageVolts;
        CurrentAmps = currentAmps;
    }

    public ElectricalPart(string article, string name, decimal price, int quantity)
        : this(article, name, UnknownManufacturer, price, quantity, DefaultVoltageVolts, DefaultCurrentAmps) { }

    public override string GetCategory()
    {
        return "Electrical";
    }

    public override string GetSpecifications()
    {
        return $"{VoltageVolts} V, {CurrentAmps} A, power {CalculatePowerWatts()} W";
    }

    public override int GetWarrantyMonths()
    {
        return 6;
    }

    public int CalculatePowerWatts()
    {
        return VoltageVolts * CurrentAmps;
    }

    public bool IsCompatibleWithVoltage(int voltageVolts)
    {
        return VoltageVolts == voltageVolts;
    }
}