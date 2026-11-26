using Homework9.task1.Abstract;

namespace Homework9.task1.Models;

public class Point : Figure
{
    public double X { get; protected set; }

    public double Y { get; protected set; }

    public Point(double x, double y, string color, bool isVisible = true)
        : base(color, isVisible)
    {
        X = x;
        Y = y;
    }

    public override void MoveHorizontal(double dx)
    {
        X += dx;
    }

    public override void MoveVertical(double dy)
    {
        Y += dy;
    }

    public void Move(double dx, double dy)
    {
        MoveHorizontal(dx);
        MoveVertical(dy);
    }

    public override void Print()
    {
        Console.WriteLine($"Figure: {GetType().Name}");
        base.Print();
        Console.WriteLine($"Coordinates: ({X:F2}; {Y:F2})");
    }
}