namespace Homework9.task2.Models;

public class Player
{
    public string Name { get; }

    public int Strength { get; }

    public int Agility { get; }

    public int Endurance { get; }

    public int Luck { get; }

    public Player(string name, Random random)
    {
        Name = name;
        Strength = random.Next(1, 11);
        Agility = random.Next(1, 11);
        Endurance = random.Next(1, 11);
        Luck = random.Next(1, 11);
    }
}