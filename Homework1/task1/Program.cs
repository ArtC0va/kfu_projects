using System;

class Program {
    static void Main() {
        //task 1.1
        Console.WriteLine("Число е: {0}", Math.E);
        double e = Math.E;
        double aE = Math.Round(e, 1);
        Console.WriteLine(aE);

        //task 1.2
        Console.WriteLine(50);
        Console.WriteLine(10);

        //task 1.3
        Random number = new Random();
        Console.WriteLine(number.Next() + "\n" + number.Next() + "\n" + number.Next() + "\n" + number.Next());
    
        //task 1.4
        Console.WriteLine("Введите целое число:");
        int num = int.Parse(Console.ReadLine());
        Console.WriteLine("Ответ: {0}", num + 10);

        //task 1.5
        Console.WriteLine("Введите значение угла в градусах:");
        double Angle = double.Parse(Console.ReadLine());
        double y = Math.Round(Math.Cos(Angle * Math.PI / 180));
        Console.WriteLine($"Косинус угла {Angle} равен: {y}");

        //task 1.6
        Console.WriteLine("Введите основания трапеции и ее высоту:");
        double up_base = double.Parse(Console.ReadLine());
        double down_base = double.Parse(Console.ReadLine());
        double h = double.Parse(Console.ReadLine());
        double perimeter = up_base + down_base + 2 * Math.Sqrt(Math.Pow((down_base - up_base) / 2, 2) + Math.Pow(h, 2));
        Console.WriteLine($"Периметр трапеции: {perimeter}");

        //task 1.7
        Console.WriteLine("Мир" + " " + "Труд" + " " + "Май");
        Console.WriteLine("Мир");
        Console.WriteLine("\t " + "Труд");
        Console.WriteLine("\t " + "\t " + "Май");

        //task 1.8
        Console.WriteLine("Введите два числа:");
        double num1 = double.Parse(Console.ReadLine());
        double num2 = double.Parse(Console.ReadLine());
        Console.WriteLine($"Результат: {num2}{num1}");

        //task 1.9
        Console.WriteLine("Введите число:");
        float num0 = float.Parse(Console.ReadLine());
        Console.WriteLine("Вы ввели число: {0}", num0);

        //task 1.10
        Console.WriteLine("Введите коэффииценты квадратного уравнения :");
        float a = float.Parse(Console.ReadLine());
        float b = float.Parse(Console.ReadLine());
        float c = float.Parse(Console.ReadLine());
        float discriminant = b * b - 4 * a * c;
        if (discriminant > 0) {
            float x11 = (-b + (float)Math.Sqrt(discriminant)) / (2 * a);
            float x22 = (-b - (float)Math.Sqrt(discriminant)) / (2 * a);
            Console.WriteLine($"Корни уравнения: {x11}, {x22}");
        } else if (discriminant == 0) {
            float x = -b / (2 * a);
            Console.WriteLine($"Корень уравнения: {x}");
        } else {
            Console.WriteLine("Уравнение не имеет действительных корней");
        }

        //task 1.11
        Console.WriteLine("Введите два числа:");
        float num01 = float.Parse(Console.ReadLine());
        float num02 = float.Parse(Console.ReadLine());
        Console.WriteLine("a) среднее арифметическое: {0}, б) среднее геометрическое: {1}", (num01 + num02) / 2, Math.Sqrt(num01 * num02));

        //task 1.12
        Console.WriteLine("Введите четыре числа - координаты двух точек:");
        float x1 = float.Parse(Console.ReadLine());
        float y1 = float.Parse(Console.ReadLine());
        float x2 = float.Parse(Console.ReadLine());
        float y2 = float.Parse(Console.ReadLine());
        float distance = (float)Math.Sqrt(Math.Pow(x2 - x1, 2) + Math.Pow(y2 - y1, 2));
        Console.WriteLine($"Расстояние между точками: {distance}");

        //task 1.13(part_a)
        Console.WriteLine("Введите три числа:");
        float a01 = float.Parse(Console.ReadLine());
        float b01 = float.Parse(Console.ReadLine());
        float c01 = float.Parse(Console.ReadLine());
        float new_num = a01;
        a01 = b01;
        b01 = c01;
        c01 = new_num;
        Console.WriteLine($"Новое значение чисел a -> b, b -> c,c -> a: {a01}, {b01}, {c01}");

        //task 1.13(part_b)
        Console.WriteLine("Введите три числа:");
        float a1 = float.Parse(Console.ReadLine());
        float b1 = float.Parse(Console.ReadLine());
        float c1 = float.Parse(Console.ReadLine());
        float new_num1 = b1;
        b1 = a1;
        a1 = c1;
        c1 = new_num1;
        Console.WriteLine($"Новое значение чисел a -> b, b -> c,c -> a: {a1}, {b1}, {c1}");

        //task 1.14
        Console.WriteLine("Введите количество секунд:");
        int seconds = int.Parse(Console.ReadLine());
        int hours = seconds / 3600;
        int minutes = (seconds % 3600) / 60;
        int remainingSeconds = seconds % 60;
        Console.WriteLine($"Время: \n a) {hours} ч \n б) {minutes} мин \n в) {remainingSeconds} сек");
    
        //task 1.15
        int width_rectangle = 543;
        int height_rectangle = 130;
        int area_rectangle = width_rectangle * height_rectangle;
        int side_square = 130;
        int area_square = side_square * side_square;
        int count_squares = area_rectangle / area_square;
        Console.WriteLine($"Количество квадратов, которые можно разместить на прямоугольнике: {count_squares}");

        //task 1.16
        Console.WriteLine("Введите трёхзначное число:");
        int number01 = int.Parse(Console.ReadLine());
        int new_number = number01 % 10 * 100 + number01 / 10;
        Console.WriteLine($"Новое число: {new_number}");

        // task 1.17
        Console.WriteLine("Введите натуральное число большее 999:");
        int number02 = int.Parse(Console.ReadLine());
        Console.WriteLine($"а) {(number02 / 1000)} тысяч; б) {(number02 / 100)} сотен");

        //task 1.18
        Console.WriteLine("Как вас зовут?");
        string name = Console.ReadLine();
        Console.WriteLine($"a){name}; б) Привет, {name} ");

        //task 1.19
        Console.WriteLine("Привет, компьютер");
        Console.WriteLine("Как вас зовут?");
        Console.WriteLine($"привет, {Console.ReadLine()}");
        Console.WriteLine("Ты знаешь что-то о тайной комнате?");
        Console.WriteLine("Да");
        Console.WriteLine("Расскажи о ней");
        Console.WriteLine("Нет");
        Thread.Sleep(5000);
        Console.WriteLine("Но могу показать");

        Random random = new Random();
        int randomColorNum = random.Next(0, 16);
        ConsoleColor randomColor = (ConsoleColor)randomColorNum;        
        Console.BackgroundColor = randomColor;
        Console.Clear();
        Thread.Sleep(5000);
        Console.BackgroundColor = ConsoleColor.Black;
        Console.Clear();

        //task 1.20
        Random random0 = new Random();
            
        string random12 = $"{random0.Next(0, 10)}{random0.Next(0, 10)}{random0.Next(0, 10)}{random0.Next(0, 10)}{random0.Next(0, 10)}{random0.Next(0, 10)}{random0.Next(0, 10)}{random0.Next(0, 10)}{random0.Next(0, 10)}{random0.Next(0, 10)}{random0.Next(0, 10)}{random0.Next(0, 10)}";
        Console.WriteLine($"Сгенерированный штрихкod (12 цифр): {random12}");

        int sum = 0;
        for (int l = 0; l < 12; l += 2) {
            int digit1 = Convert.ToInt32($"{random12[l]}");
            int digit2 = Convert.ToInt32($"{random12[l + 1]}");

            sum += digit1 * 3 + digit2;
        }
            
        int checkDigitRandom = (10 - (sum % 10)) % 10;
        Console.WriteLine($"Контрольная цифра для случайного штрихкода: {checkDigitRandom}");
        Console.WriteLine();

        Console.WriteLine("Введите 12 цифр штрихкода (нажимайте Enter после каждой цифры):");

        string ls = $"{Console.ReadLine()}{Console.ReadLine()}{Console.ReadLine()}{Console.ReadLine()}{Console.ReadLine()}{Console.ReadLine()}{Console.ReadLine()}{Console.ReadLine()}{Console.ReadLine()}{Console.ReadLine()}{Console.ReadLine()}{Console.ReadLine()}";
            
        sum = 0;
        for (int l = 0; l < 12; l += 2){
            int digit1 = Convert.ToInt32($"{ls[l]}");
            int digit2 = Convert.ToInt32($"{ls[l + 1]}");

            sum += digit1 * 3 + digit2;
        }
            
        int checkDigitUser = (10 - (sum % 10)) % 10;
        Console.WriteLine($"Контрольная цифра для вашего ввода: {checkDigitUser}");
    }
}