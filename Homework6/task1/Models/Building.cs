namespace Homework6.task1.Models;

public class Building
{
    private static int _lastNum;

    private int _num;
    private double _height;
    private int _floors;
    private int _apartments;
    private int _entrances;

    private static int GenerateNumber()
    {
        _lastNum++;
        return _lastNum;
    }

    public int GetNumber()
    {
        return _num;
    }

    public double GetHeight()
    {
        return _height;
    }

    public int GetFloors()
    {
        return _floors;
    }

    public int GetApartments()
    {
        return _apartments;
    }

    public int GetEntrances()
    {
        return _entrances;
    }

    public void SetHeight(double height)
    {
        if (height <= 0)
        {
            throw new ArgumentOutOfRangeException(
                nameof(height),
                "Height must be positive.");
        }

        _height = height;
    }
    public void SetFloors(int floors)
    {
        if (floors < 1)
        {
            throw new ArgumentOutOfRangeException(
                nameof(floors),
                "A building must have at least one floor.");
        }

        _floors = floors;
    }

    public void SetApartments(int apartments)
    {
        if (apartments < 1)
        {
            throw new ArgumentOutOfRangeException(
                nameof(apartments),
                "A building must have at least one apartment.");
        }

        _apartments = apartments;
    }

    public void SetEntrances(int entrances)
    {
        if (entrances < 1)
        {
            throw new ArgumentOutOfRangeException(
                nameof(entrances),
                "A building must have at least one entrance.");
        }

        _entrances = entrances;
    }



    public Building(double height, int floors, int apartments, int entrances)
    {
        _num = GenerateNumber();
        SetHeight(height);
        SetFloors(floors);
        SetApartments(apartments);
        SetEntrances(entrances);
    }

    public double CalculateFloorHeight()
    {
        return _height / _floors;
    }

    public double CalculateApartmentsPerEntrance()
    {
        return (double)_apartments / _entrances;
    }

    public double CalculateApartmentsPerFloor()
    {
        return (double)_apartments / _floors;
    }
    public override string ToString()
    {
        return $"Building #{_num}: height {_height:F1} m, floors {_floors}, "
            + $"apartments {_apartments}, entrances {_entrances}";
    }
}