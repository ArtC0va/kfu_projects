namespace Homework3.Methods;

public static class CardValue
{
    public static string GetCardName(int cardValueNumber)
    {
        return cardValueNumber switch
        {
            6 => "six",
            7 => "seven",
            8 => "Eight",
            9 => "Nine",
            10 => "Ten", 
            11 => "Jack",
            12 => "Queen",
            13 => "King",
            14 => "Ace",
            _ => throw new ArgumentOutOfRangeException(
                nameof(cardValueNumber),
                $"Card value must be from 6 to 14")
        };
    }
}