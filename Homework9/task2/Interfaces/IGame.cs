using Homework9.task2.Models;

namespace Homework9.task2.Interfaces;

public interface IGame
{
    string Name { get; }

    string Description { get; }

    double Play(Team team, Random random);
}