using Homework9.task2.Models;
using Homework9.task2.Interfaces;

namespace Homework9.task2.Games;

public abstract class Game : IGame
{
    public string Name { get; }

    public string Description { get; }

    protected Game(string name, string description)
    {
        Name = name;
        Description = description;
    }

    public double Play(Team team, Random random)
    {
        double total = 0;

        foreach (Player player in team.Players)
        {
            total += GetPlayerScore(player, random);
        }

        return Math.Round(total / team.Players.Count, 2);
    }

    protected abstract double GetPlayerScore(Player player, Random random);
}