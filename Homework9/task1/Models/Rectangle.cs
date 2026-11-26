using Homework9.task1.Interfaces;

namespace Homework9.task1.Models;

public class Rectangle : Point, IAreaCalculable
{
    public double Width { get; }

    public double Height { get; }

    public Rectangle(double x, double y, double width, double height, string color, bool isVisible = true)
        : base(x, y, color, isVisible)
    {
        Width = width;
        Height = height;
    }

    public double GetArea()
    {
        return Width * Height;
    }

    public override void Print()
    {
        base.Print();
        Console.WriteLine($"Width: {Width:F2}");
        Console.WriteLine($"Height: {Height:F2}");
        Console.WriteLine($"Area: {GetArea():F2}");
    }
}