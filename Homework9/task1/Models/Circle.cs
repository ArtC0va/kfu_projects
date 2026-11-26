using Homework9.task1.Interfaces;

namespace Homework9.task1.Models;

public class Circle : Point, IAreaCalculable
{
    public double Radius { get; }

    public Circle(double x, double y, double radius, string color, bool isVisible = true)
        : base(x, y, color, isVisible)
    {
        Radius = radius;
    }

    public double GetArea()
    {
        return Math.PI * Radius * Radius;
    }

    public override void Print()
    {
        base.Print();
        Console.WriteLine($"Radius: {Radius:F2}");
        Console.WriteLine($"Area: {GetArea():F2}");
    }
}