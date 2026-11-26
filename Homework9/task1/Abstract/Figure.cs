using Homework9.task1.Interfaces;

namespace Homework9.task1.Abstract;

public abstract class Figure : IMovable, IColorable
{
    public string Color { get; private set; }

    public bool IsVisible { get; private set; }

    protected Figure(string color, bool isVisible = true)
    {
        Color = color;
        IsVisible = isVisible;
    }

    public abstract void MoveHorizontal(double dx);

    public abstract void MoveVertical(double dy);

    public void ChangeColor(string color)
    {
        Color = color;
    }

    public void Show()
    {
        IsVisible = true;
    }

    public void Hide()
    {
        IsVisible = false;
    }

    public virtual void Print()
    {
        Console.WriteLine($"Color: {Color}");
        Console.WriteLine($"Состояние: {(IsVisible ? "Visible" : "Invisible")}");
    }
}