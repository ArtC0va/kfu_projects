using Homework8.task1.Models;
using Homework8.task1.Enums;
using GeneralMethods;

namespace Homework8.task1
{
    public class Program
    {
        public static void Main()
        {
            Task1();
        }

        private static void Task1()
        {
            Bank account0 = new Bank(
                InputMethods.ReadValue<decimal>(
                    "Enter the account balance",
                    decimal.TryParse,
                    errorMessage: "This isn't a number")
            );

            Bank account1 = new Bank(
                InputMethods.ReadEnum<AccountType>(
                    "Choose the account type:")
            );

            Bank account2 = new Bank(
                InputMethods.ReadValue<decimal>(
                    "Enter the account balance",
                    decimal.TryParse,
                    errorMessage: "This isn't a number"),
                InputMethods.ReadEnum<AccountType>(
                    "Choose the account type:")
            );

            Console.WriteLine($"{account0.AccountNumber},\n{account0.Balance},\n{account0.Type}\n");
            Console.WriteLine($"{account1.AccountNumber},\n{account1.Balance},\n{account1.Type}\n");
            Console.WriteLine($"{account2.AccountNumber},\n{account2.Balance},\n{account2.Type}\n");
        }
    }
}
