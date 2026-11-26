using Homework9.task2.Models;

namespace Homework9.task2.Games;

public class TugOfWarGame : Game
{
    public TugOfWarGame()
        : base("Tug Of War", "Tug of war game: Strength")
    {
    }

    protected override double GetPlayerScore(Player player, Random random)
    {
        return player.Strength * 2 + random.Next(0, 6);
    }
}