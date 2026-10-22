namespace Homework5.Task1.Methods;

public static class MatrixMethods
{
    public static int[,] CreateRandom(int rows, int columns, int minValue, int maxValueExclusive)
    {
        int[,] matrix = new int[rows, columns];

        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < columns; j++)
            {
                matrix[i, j] = Random.Shared.Next(minValue, maxValueExclusive);
            }
        }

        return matrix;
    }

    public static void Print(int[,] matrix)
    {
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                Console.Write($"{matrix[i, j],5}");
            }

            Console.WriteLine();
        }
    }

    public static int[,] Multiply(int[,] left, int[,] right)
    {
        int leftRows = left.GetLength(0);
        int leftColumns = left.GetLength(1);
        int rightRows = right.GetLength(0);
        int rightColumns = right.GetLength(1);

        if (leftColumns != rightRows)
        {
            throw new ArgumentException(
                $"Cannot multiply: the first matrix has {leftColumns} columns, the second has {rightRows} rows.");
        }

        int[,] result = new int[leftRows, rightColumns];

        for (int i = 0; i < leftRows; i++)
        {
            for (int j = 0; j < rightColumns; j++)
            {
                int sum = 0;

                for (int k = 0; k < leftColumns; k++)
                {
                    sum += left[i, k] * right[k, j];
                }

                result[i, j] = sum;
            }
        }

        return result;
    }

    public static bool AreEqual(int[,] first, int[,] second)
    {
        if (first.GetLength(0) != second.GetLength(0) || first.GetLength(1) != second.GetLength(1))
        {
            return false;
        }

        for (int i = 0; i < first.GetLength(0); i++)
        {
            for (int j = 0; j < first.GetLength(1); j++)
            {
                if (first[i, j] != second[i, j])
                {
                    return false;
                }
            }
        }

        return true;
    }
}