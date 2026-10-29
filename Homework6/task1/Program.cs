using GeneralMethods;
using Homework6.task1.Enums;
using Homework6.task1.Models;

namespace Homework6
{
    public class Program
    {
        static void Main()
        {
            Task1();
            Task2();
            Task3();
            Hometask1();
        }

        private static void Task1()
        {
            Bank account = new Bank();
            account.SetBalance(InputMethods.ReadValue<decimal>(
                "Enter the account balance",
                decimal.TryParse,
                errorMessage: "This isn't a number"));
            account.SetAccountType(InputMethods.ReadEnum<AccountType>(
                "Choose the account type:"));

            Console.WriteLine($"Account number: {account.GetNumber()}");
            Console.WriteLine($"Balance: {account.GetBalance():F2}");
            Console.WriteLine($"Type: {account.GetAccountType()}");
            Console.WriteLine(account);
        }

        private static void Task2()
        {
            Bank firstAccount = new Bank(
                InputMethods.ReadValue<decimal>(
                    "Enter the balance for the first account",
                    decimal.TryParse,
                    errorMessage: "This isn't a number"),
                InputMethods.ReadEnum<AccountType>(
                    "Choose the type for the first account type:"));
            Bank secondAccount = new Bank(
                InputMethods.ReadValue<decimal>(
                    "Enter the balance for the second account",
                    decimal.TryParse,
                    errorMessage: "This isn't a number"),
                InputMethods.ReadEnum<AccountType>(
                    "Choose the type for the second account type:"));
            Bank thirdAccount = new Bank(
                InputMethods.ReadValue<decimal>(
                    "Enter the balance for the third account",
                    decimal.TryParse,
                    errorMessage: "This isn't a number"),
                InputMethods.ReadEnum<AccountType>(
                    "Choose the type for the third account type:"));

            Console.WriteLine(firstAccount);
            Console.WriteLine(secondAccount);
            Console.WriteLine(thirdAccount);
        }

        private static void Task3()
        {
            Bank account = new Bank(
                InputMethods.ReadValue<decimal>(
                    "Enter the account balance",
                    decimal.TryParse,
                    errorMessage: "This isn't a number"),
                InputMethods.ReadEnum<AccountType>(
                    "Choose the account type:"));
            Console.WriteLine(account);

            decimal amount = InputMethods.ReadValue<decimal>(
                "Enter the amount to withdraw",
                decimal.TryParse,
                errorMessage: "This isn't a number");

            if (account.Withdraw(amount))
            {
                Console.WriteLine($"Withdraw {amount:F2}. New balance {account.GetBalance():F2}");
            }
            else
            {
                Console.WriteLine($"Cannot withdraw {amount:F2}. Balance {account.GetBalance():F2}");
            }
        }

        private static void Hometask1()
        {
            Building building = new Building(
                InputMethods.ReadValue<double>(
                    "Enter the height in metres",
                    double.TryParse,
                    value => value > 0,
                    "Enter a positive number"),
                InputMethods.ReadValue<int>(
                    "Enter the number of floors",
                    int.TryParse,
                    value => value > 1,
                    "Enter an integer 1 or greater"),
                InputMethods.ReadValue<int>(
                    "Enter the number of apartments",
                    int.TryParse,
                    value => value > 1,
                    "Enter an integer 1 or greater"),
                InputMethods.ReadValue<int>(
                    "Enter the number of entrances",
                    int.TryParse,
                    value => value > 1,
                    "Enter an integer 1 or greater"));

            Console.WriteLine(building);
            Console.WriteLine($"Floor height: {building.CalculateFloorHeight():F2} m");
            Console.WriteLine($"Apartments per entrance: {building.CalculateApartmentsPerEntrance():F2}");
            Console.WriteLine($"Apartments per floor: {building.CalculateApartmentsPerFloor():F2}");
        }
    }
}
