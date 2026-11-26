using GeneralMethods;
using Homework9.task1.Abstract;
using Homework9.task1.Interfaces;
using Homework9.task1.Models;
using Homework9.task1.Services;

namespace Homework9.task1;

public static class Program
{
    public static void Main()
    {
        Task1();
        Hometask1();
    }

    private static void Task1()
    {
        string text = InputMethods.ReadString("Enter the string: ");

        ICipher[] ciphers =
        {
            new ACipher(),
            new BCipher()
        };

        foreach (ICipher cipher in ciphers)
        {
            string encoded = cipher.Encode(text);
            string decoded = cipher.Decode(encoded);

            Console.WriteLine();
            Console.WriteLine($"[{cipher.GetType().Name}]");
            Console.WriteLine($"Encrypted: {encoded}");
            Console.WriteLine($"Deciphered: {decoded}");
        }
    }

    private static void Hometask1()
    {
        string color = InputMethods.ReadString("Enter color");
        double x = InputMethods.ReadValue<double>(
            "Enter x:",
            double.TryParse,
            errorMessage: "Enter positive number");
        double y = InputMethods.ReadValue<double>(
            "Enter y:",
            double.TryParse,
            errorMessage: "Enter positive number");
        double radius = InputMethods.ReadValue<double>(
            "Enter radius:",
            double.TryParse,
            value => value > 0,
            "Enter positive number");
        double width = InputMethods.ReadValue<double>(
            "Enter width:",
            double.TryParse,
            value => value > 0,
            "Enter positive number");
        double height = InputMethods.ReadValue<double>(
            "Enter height:",
            double.TryParse,
            value => value > 0,
            "Enter positive number");
        
        Figure[] figures =
        {
            new Point(x, y, color),
            new Circle(x, y, radius, color),
            new Rectangle(x, y, width, height, color)
        };

        Console.WriteLine();
        PrintAll(figures);

        double dx = InputMethods.ReadValue<double>(
            "Enter x:",
            double.TryParse,
            errorMessage: "Enter number");
        double dy = InputMethods.ReadValue<double>(
            "Enter y:",
            double.TryParse,
            errorMessage: "Enter positive number");
        string newColor = InputMethods.ReadString("Enter color");

        foreach (Figure figure in figures)
        {
            if (figure is Point point)
            {
                point.Move(dx, dy);
            }
            figure.ChangeColor(newColor);
        }

        Console.WriteLine();
        PrintAll(figures);

        foreach (Figure figure in figures)
        {
            figure.Hide();
        }

        Console.WriteLine();
        foreach (Figure figure in figures)
        {
            Console.WriteLine($"{figure.GetType().Name} is visible: {figure.IsVisible}");
        }
    }

    private static void PrintAll(Figure[] figures)
    {
        foreach (Figure figure in figures)
        {
            figure.Print();
            Console.WriteLine();
        }
    }
}



