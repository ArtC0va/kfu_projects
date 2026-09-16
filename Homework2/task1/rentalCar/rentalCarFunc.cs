namespace Homework2.rentalCar
{
    public static class RentalCarFunc
    {
        public static T GetInfo<T>(string message, Func<string?, (bool isTrue, T value)> parseFunc)
        {
            while (true)
            {
                Console.WriteLine(message);
                string? input = Console.ReadLine();
                var result = parseFunc(input);
                if (result.isTrue)
                    return result.value;
                else
                    Console.WriteLine("This is not the right information");
            }
        }

        public static (string?, string?, Class, DateOnly, DateOnly, float) ToRentalCar(this RentalCar rentalCar)
        {
            return (rentalCar.Name, rentalCar.Brand, rentalCar.ClassOfCar, rentalCar.StartDate, rentalCar.EndDate, rentalCar.Price);
        }

        public static void PrintOnScreen(RentalCar rentalCar)
        {
            Console.WriteLine($"Name - {rentalCar.Name} \nCar brend - {rentalCar.Brand} \tCar class - {rentalCar.ClassOfCar} \nStart - {rentalCar.StartDate} \tEnd - {rentalCar.EndDate} \nPrice - {rentalCar.Price}$/day");
        }

        public static string? EnterInfo(string? message)
        {
            Console.WriteLine(message);
            string? input = Console.ReadLine();
            return input;

        }
    }
}