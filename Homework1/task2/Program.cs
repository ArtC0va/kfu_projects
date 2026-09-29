using System;

class Program {
    static void Main() {
        //task 2.1
        Console.WriteLine("Как вас зовут?");
        string name = Console.ReadLine();
        Console.WriteLine($"Привет, {name} ");
        
        //task 2.2
        Console.WriteLine("Введите два целых числа:");
        int num1 = int.Parse(Console.ReadLine());
        int num2 = int.Parse(Console.ReadLine());
        if (num2 != 0) {
            float res_num = (float)num1/num2;
            Console.WriteLine($"Результат деления: {res_num}");
        } else {
            Console.WriteLine("Деление на нуль");
        }

        //hometask 2.1
        Console.WriteLine("Введите букву:");
        string input = Console.ReadLine();
        char letter = input[0];
        char nextLetter = (char)(letter + 1);
        Console.WriteLine($"Следующая буква: {nextLetter}");
        
        //hometask 2.2
        Console.WriteLine("Введите коэффииценты квадратного уравнения :");
        float a = float.Parse(Console.ReadLine());
        float b = float.Parse(Console.ReadLine());
        float c = float.Parse(Console.ReadLine());
        float discriminant = b * b - 4 * a * c;
        if (discriminant > 0) {
            float x1 = (-b + (float)Math.Sqrt(discriminant)) / (2 * a);
            float x2 = (-b - (float)Math.Sqrt(discriminant)) / (2 * a);
            Console.WriteLine($"Корни уравнения: {x1}, {x2}");
        } else if (discriminant == 0) {
            float x = -b / (2 * a);
            Console.WriteLine($"Корень уравнения: {x}");
        } else {
            Console.WriteLine("Уравнение не имеет действительных корней");
        }
    }
}
