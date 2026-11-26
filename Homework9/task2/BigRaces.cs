using GeneralMethods;
using Homework9.task2.Games;
using Homework9.task2.Models;
using Homework9.task2.Interfaces;

namespace Homework9.task2;

public class BigRaces
{
    private readonly List<Team> _teams;
    private readonly List<IGame> _games = new List<IGame>();
    private readonly Random _random;

    public BigRaces(IEnumerable<Team> teams, Random random)
    {
        _teams = new List<Team>(teams);
        _random = random;
    }

    public void AddGame(IGame game)
    {
        _games.Add(game);
    }

    public void Run()
    {
        Console.WriteLine($"Teams: {_teams.Count}, games: {_games.Count}.");

        for (int i = 0; i < _games.Count; i++)
        {
            Console.WriteLine();
            Console.WriteLine($"Game {i + 1} from {_games.Count}: {_games[i].Name} ===");
            Console.WriteLine(_games[i].Description);

            InputMethods.ReadValue<int>(
                "Enter 1 to start:",
                int.TryParse,
                number => number == 1,
                "Enter 1");

            PlayGame(_games[i]);
        }

        PrintFinalTable();
    }

    private void PlayGame(IGame game)
    {
        List<(Team Team, double Score)> results = new List<(Team Team, double Score)>();

        foreach (Team team in _teams)
        {
            results.Add((team, game.Play(team, _random)));
        }

        results.Sort((a, b) => b.Score.CompareTo(a.Score));

        for (int place = 0; place < results.Count; place++)
        {
            int points = results.Count - place;
            results[place].Team.AddResult(points, results[place].Score);

            Console.WriteLine($"{place + 1} place: {results[place].Team.Name} - result {results[place].Score:F2}, score {points}");
        }
    }

    private void PrintFinalTable()
    {
        List<Team> table = new List<Team>(_teams);
        table.Sort((a, b) =>
        {
            int byPoints = b.TotalPoints.CompareTo(a.TotalPoints);
            return byPoints != 0 ? byPoints : b.TotalScore.CompareTo(a.TotalScore);
        });

        Console.WriteLine();
        Console.WriteLine("TABLE");

        for (int i = 0; i < table.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {table[i].Name} - score {table[i].TotalPoints}, sum result {table[i].TotalScore:F2}");
        }

        Console.WriteLine();
        Console.WriteLine($"Show win: {table[0].Name}!");
    }
}