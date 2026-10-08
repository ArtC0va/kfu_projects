using Homework4.Task2.Models;
using Homework4.Task2.Enums;

namespace Homework4.Task2.Services;

public static class NewGrandpa
{
    public static Grandpa[] CreateGrandpas()
    {
        return new[]
        {
            new Grandpa("Николай", GrumpinessLevel.Mild, new[] { "Эх, молодёжь!" }),
            new Grandpa("Пётр", GrumpinessLevel.Moderate, new[] { "Гады!", "Ну и погодка!" }),
            new Grandpa("Иван", GrumpinessLevel.Severe, new[] { "Балбесы!", "Тунеядцы!", "Куда катимся?" }),
            new Grandpa("Фёдор", GrumpinessLevel.Severe, new[] { "Гады!", "Балбесы!", "Тунеядцы!", "Безобразие!" }),
            new Grandpa("Семён", GrumpinessLevel.Extreme, new[] { "Гады!", "Гады, гады!", "Балбесы!", "Тунеядцы!", "Ох, ну и дела!" })
        };
    }
}