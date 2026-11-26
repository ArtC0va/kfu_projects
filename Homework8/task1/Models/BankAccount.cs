using Homework8.task1.Enums;

namespace Homework8.task1.Models;

public class Bank
{
    private static int _counter = 0;

    private string _accountNumber;
    private decimal _balance;
    private AccountType _type;

    public Bank()
    {
        _balance = 0;
        _type = AccountType.Current;
       _accountNumber = GenerateAccountNumber();
    }

    public Bank(decimal balance)
    {
        _balance = balance;
        _type = AccountType.Current;
       _accountNumber = GenerateAccountNumber();
    }

    public Bank(AccountType type)
    {
        _balance = 0;
        _type = type;
       _accountNumber = GenerateAccountNumber();
    }

    public Bank(decimal balance, AccountType type)
    {
        _balance = balance;
        _type = type;
       _accountNumber = GenerateAccountNumber();
    }

    private static string GenerateAccountNumber()
    {
        _counter++;
        return $"50069{_counter:D15}";
    }

    public string AccountNumber => _accountNumber;
    public decimal Balance => _balance;
    public AccountType Type => _type;
}