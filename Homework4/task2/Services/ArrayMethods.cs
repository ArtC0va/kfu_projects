namespace Homework4.Task2.Services;

public static class ArrayMethods
{
    public static int[] CreateRandomArray(int length, int minValue, int maxValue)
    {
        int[] result = new int[length];

        for (int i = 0; i < result.Length; i++)
        {
            result[i] = Random.Shared.Next(minValue, maxValue);
        }

        return result;
    }

    public static void SwapValues(int[] array, int firstValue, int secondValue)
    {
        int firstIndex = Array.IndexOf(array, firstValue);
        int secondIndex = Array.IndexOf(array, secondValue);

        if (firstIndex < 0 || secondIndex < 0)
        {
            throw new ArgumentException(
                "Both values must be from the array");
        }

        Swap(ref array[firstIndex], ref array[secondIndex]);
    }

    public static void Swap(ref int first, ref int second)
    {
        int addElement = first;
        first = second;
        second = addElement;
    }

    public static long SumProductAverage(ref long product, out double average, params int[] numbers)
    {
        if (numbers.Length == 0)
        {
            throw new ArgumentException(
                "At least one number is needed",
                nameof(numbers));
        }

        long sum = 0;

        foreach (int number in numbers)
        {
            sum += number;
            product *= number;
        }

        average = (double)sum / numbers.Length;
        return sum;
    }
}