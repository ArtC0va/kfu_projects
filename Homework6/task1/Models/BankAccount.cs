using Homework6.task1.Enums;

namespace Homework6.task1.Models;

public class Bank
{
    // 1
    private readonly int _number;
    private decimal _balance;
    private AccountType _type;

    public Bank() : this(0m, AccountType.Current) {}

    public int GetNumber()
    {
        return _number;
    }

    public decimal GetBalance()
    {
        return _balance;
    }

    public AccountType GetAccountType()
    {
        return _type;
    }

    public void SetBalance(decimal balance)
    {
        if (balance < 0)
        {
            throw new ArgumentOutOfRangeException( 
                nameof(balance), 
                "Balance cannot be negative, that is called debt.");
        }

        _balance = balance;
    }

    public void SetAccountType(AccountType type)
    {
        if (!Enum.IsDefined(type))
        {
            throw new ArgumentOutOfRangeException( 
                nameof(type), 
                "Unknown account type.");
        }

        _type = type;
    }

    public override string ToString()
    {
        return $"Account #{_number}, type: {_type}, balance: {_balance:F2}";
    }

    // 2
    private static int _lastNum = 0;

    public Bank(decimal balance, AccountType type)
    {
        _number = GenerateNumber();
        SetBalance(balance);
        SetAccountType(type);
    }

    private static int GenerateNumber()
    {
        _lastNum++;
        return _lastNum;
    }

    // 3
    public bool Deposit(decimal amount)
    {
        if (amount <= 0)
        {
            return false;
        }

        _balance += amount;
        return true;
    }

    public bool Withdraw(decimal amount)
    {
        if (amount <= 0 || amount > _balance)
        {
            return false;
        }

        _balance -= amount;
        return true;
    }
}
