namespace Homework2.user
{
    public static class UserFunc
    {
        public static string? EnterInfo(string? message)
        {
            Console.WriteLine(message);
            var input = Console.ReadLine();
            return input;
        }

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

        public static void PrintOnScreen(User user)
        {
            Console.WriteLine($"\nName: {user.Name} \nCity: {user.City} \nAge: {user.Age} \nPin: {user.PIN}");
        }

        public static (string?, string?, byte, string?) ToUser(this User user)
        {
            return (user.Name, user.City, user.Age, user.PIN);
        }
    }
}