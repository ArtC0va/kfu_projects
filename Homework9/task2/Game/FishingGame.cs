using Homework9.task2.Models;

namespace Homework9.task2.Games;

public class FishingGame : Game
{
    public FishingGame()
        : base("Fishing", "Fishing game: Luck")
    {
    }

    protected override double GetPlayerScore(Player player, Random random)
    {
        return player.Luck * 2 + random.Next(0, 6);
    }
}