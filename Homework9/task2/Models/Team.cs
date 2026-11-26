namespace Homework9.task2.Models;

public class Team
{
    private readonly List<Player> _players = new List<Player>();

    public string Name { get; }

    public IReadOnlyList<Player> Players => _players;

    public int TotalPoints { get; private set; }

    public double TotalScore { get; private set; }

    public Team(string name, int playersCount, Random random)
    {
        Name = name;

        for (int i = 1; i <= playersCount; i++)
        {
            _players.Add(new Player($"{name}-{i}", random));
        }
    }

    public void AddResult(int points, double score)
    {
        TotalPoints += points;
        TotalScore += score;
    }
}