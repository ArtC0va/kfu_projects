using System;
using Homework2.user;

namespace Homework2
{
    public class Program
    {
        public static void Main()
        {
            //task 1
            Console.WriteLine($"Sbyte: from {sbyte.MinValue} to {sbyte.MaxValue}");
            Console.WriteLine($"Short: from {short.MinValue} to {short.MaxValue}");
            Console.WriteLine($"Int: from {int.MinValue} to {int.MaxValue}");
            Console.WriteLine($"Long: from {long.MinValue} to {long.MaxValue}");
            Console.WriteLine($"IntPtr: from {IntPtr.MinValue} to {IntPtr.MaxValue}");
            Console.WriteLine($"Byte: from {byte.MinValue} to {byte.MaxValue}");
            Console.WriteLine($"Ushort: from {ushort.MinValue} to {ushort.MaxValue}");
            Console.WriteLine($"Uint: from {uint.MinValue} to {uint.MaxValue}");
            Console.WriteLine($"Ulong: from {ulong.MinValue} to {ulong.MaxValue}");
            Console.WriteLine($"UIntPtr: from {UIntPtr.MinValue} to {UIntPtr.MaxValue}");
            Console.WriteLine($"Float: from {float.MinValue} to {float.MaxValue}");
            Console.WriteLine($"Double: from {double.MinValue} to {double.MaxValue}");
            Console.WriteLine($"Decimal: from {decimal.MinValue} to {decimal.MaxValue}");
            Console.WriteLine($"Char: from {char.MinValue} to {char.MaxValue}");
            Console.WriteLine($"DateTime: from {DateTime.MinValue} to {DateTime.MaxValue}");
            Console.WriteLine($"DateOnly: from {DateOnly.MinValue} to {DateOnly.MaxValue}");
            Console.WriteLine($"TimeOnly: from {TimeOnly.MinValue} to {TimeOnly.MaxValue}");
            Console.WriteLine($"TimeSpan: from {TimeSpan.MinValue} to {TimeSpan.MaxValue}");

            //task 2
            List<(string? name, string? city, byte age, string? pin)> userList = new();
            
            User user0 = new User
            {
                Name = UserFunc.EnterInfo("Enter name"),
                City = UserFunc.EnterInfo("Enter city"),
                Age = UserFunc.GetInfo<byte>("Enter age", s => (byte.TryParse(s, out byte res), res)),
                PIN = UserFunc.EnterInfo("Enter pin")
            };
            userList.Add(user0.ToUser());
            UserFunc.PrintOnScreen(user0);

            //task 3
            var input = Console.ReadLine();
            var newStr = TextFunc.TextShift(input);
            Console.WriteLine(newStr);
        }
    }
}
