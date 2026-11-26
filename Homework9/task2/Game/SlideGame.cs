using Homework9.task2.Models;

namespace Homework9.task2.Games;

public class SlideGame : Game
{
    public SlideGame()
        : base("Slide", "Slide game: Luck and Strength")
    {
    }

    protected override double GetPlayerScore(Player player, Random random)
    {
        return player.Luck + player.Strength + random.Next(0, 6);
    }
}