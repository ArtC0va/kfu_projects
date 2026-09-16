namespace Homework2
{
    public static class TextFunc
    {
        public static string? TextShift(string? input)
        {
            if (string.IsNullOrEmpty(input)) return input;

            return new string(input.Select(c => char.IsLower(c) ? char.ToUpper(c) : char.ToLower(c)).ToArray());
        }
    }
}