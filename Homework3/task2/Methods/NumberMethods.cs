using Methods;

namespace Homework3.Methods;

public static class NumberMethods
{
    private const int NumbersCount = 10;
    public const int NotFound = -1;
    public static double[] ReadNumbers()
    {
        double[] numbers = new double[NumbersCount];

        for (int i = 0; i < numbers.Length; i++)
        {
            numbers[i] = InputMethods.ReadValue<double>(
            $"Enter number",
            double.TryParse,
            errorMessage: "This isn't a number");
        }

        return numbers;
    }

    public static int FindFirstViolation(double[] numbers)
    {
        int violationIndex = NotFound;

        for (int i = 1; i < numbers.Length; i++)
        {
            if (numbers[i] <= numbers[i - 1])
            {
                violationIndex = i;
                break;
            }
        }

        return violationIndex;
    }
}