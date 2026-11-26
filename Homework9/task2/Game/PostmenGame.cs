using Homework9.task2.Models;

namespace Homework9.task2.Games;

public class PostmenGame : Game
{
    public PostmenGame()
        : base("Postmen", "Postman game: Endurance and Agility")
    {
    }

    protected override double GetPlayerScore(Player player, Random random)
    {
        return player.Endurance + player.Agility + random.Next(0, 6);
    }
}