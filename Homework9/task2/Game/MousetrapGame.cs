using Homework9.task2.Models;

namespace Homework9.task2.Games;

public class MousetrapGame : Game
{
    public MousetrapGame()
        : base("Mousetrap", "Mousetrap game: Agility and Luck")
    {
    }

    protected override double GetPlayerScore(Player player, Random random)
    {
        return player.Agility + player.Luck + random.Next(0, 6);
    }
}