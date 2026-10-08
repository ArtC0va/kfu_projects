using System.Runtime.ExceptionServices;

namespace Homework4.Methods;

public static class MainMethods
{
    public static int FindMax(int num1, int num2)
    {
        return num1 > num2 ? num1 : num2;
    }

    public static (string, string) Swap(string arg1, string arg2)
    {
        var addArg = arg1;
        arg1 = arg2;
        arg2 = addArg;

        return (arg1, arg2);
    }

    public static bool TryFactorial(int num, out long result)
    {
        if (num < 0) 
        {
            throw new ArgumentOutOfRangeException(
                nameof(num),
                "Factorial is defined only for natural numbers");
        }

        long factRes = 1;

        try
        {
            checked
            {
                for (int i = 2; i <= num; i++)
                {
                    factRes *= i;
                }
            }
        }
        catch (OverflowException)
        {
            result = 0;
            return false;
        }

        result = factRes;
        return true;
    }
    
    public static long FactorialRecursive(int num)
    {
        if (num < 0)
        {
            throw new ArgumentOutOfRangeException(
                nameof(num),
            "Factorial is defined only for natural number");
        }

        if (num == 0)
        {
            return 1;
        }

        return checked(num * FactorialRecursive(num - 1));
    }

    public static int GCD(int num1, int num2)
    {
        if (num1 <= 0 || num2 <= 0)
        {
            throw new ArgumentOutOfRangeException(
                nameof(num1),
            "Numbers must be natural");
        }

        while (num2 != 0)
        {
            int remainder = num1 % num2;
            num1 = num2;
            num2 = remainder;
        }

        return num1;
    }

    public static int GCD(int num1, int num2, int num3)
    {
        return GCD(GCD(num1, num2), num3);
    }

    public static long FNum(int num)
    {
        if (num < 1)
        {
            throw new ArgumentOutOfRangeException(
                nameof(num),
            "Numbers must be natural");
        }

        if (num <= 2)
        {
            return 1;
        }

        return FNum(num - 1) + FNum(num - 2);
    }

}