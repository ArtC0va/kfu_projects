namespace Homework2.spaceman
{
    public static class SpacemanFunc
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
                    Console.WriteLine("This is not the real information");
            }
        }

        public static void PrintOnScreen(Spaceman person)
        {
            Console.WriteLine($"Name - {person.Name}, \t Age - {person.Age}, \t Height - {person.Height}, \t Weight - {person.Weight}, \t Favorite film about Space - {person.FavoriteFilmAboutSpace}");
        }
        
        public static string? EnterInfo(string? message)
        {
            Console.WriteLine(message);
            string? input = Console.ReadLine();
            return input;

        }
    }
}