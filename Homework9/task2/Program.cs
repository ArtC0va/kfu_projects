using Homework9.task2.Games;
using Homework9.task2.Models;

namespace Homework9.task2;

public static class Program
{
    private const int PlayersInTeam = 15;

    public static void Main()
    {
        Console.WriteLine();
        Console.WriteLine("Enter '1' to start");

        Random random = new Random();

        Team[] teams =
        {
            new Team("Франция", PlayersInTeam, random),
            new Team("Китай", PlayersInTeam, random),
            new Team("Россия", PlayersInTeam, random),
            new Team("Казахстан", PlayersInTeam, random),
        };

        BigRaces show = new BigRaces(teams, random);

        show.AddGame(new BeachGame());
        show.AddGame(new MousetrapGame());
        show.AddGame(new SeaGame());
        show.AddGame(new FishingGame());
        show.AddGame(new PostmenGame());
        show.AddGame(new SlideGame());

        show.AddGame(new TugOfWarGame());

        show.Run();
    }
}