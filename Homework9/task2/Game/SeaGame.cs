using Homework9.task2.Models;

namespace Homework9.task2.Games;

public class SeaGame : Game
{
    public SeaGame()
        : base("Sea", "Sea game: Endurance and Strength")
    {
    }

    protected override double GetPlayerScore(Player player, Random random)
    {
        return player.Endurance + player.Strength + random.Next(0, 6);
    }
}