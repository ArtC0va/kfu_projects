using System;
using Homework2.bank;
using Homework2.university;

namespace Homework2
{
    class Program
    {
        static void Main()
        {
            //Тумаков

            //task 3.1
            BankType personsAccount = BankType.Savings;
            Console.WriteLine($"Bank account: {personsAccount}\n");

            //task 3.2
            Bank Account = new Bank
            {
                Id = "1215673", 
                Type = BankType.Current,
                Balance = 1000.80F
            };

            Console.WriteLine($"Account: {Account.Id} \nAccount type: {Account.Type} \nBalance: {Account.Balance}\n");
        
            //hometask 3.1
            Worker person0 = new Worker
            {
                Id = "Person0",
                Name = "Bob",
                University = University.KAI
            };
            Worker person1 = new Worker
            {
                Id = "Person1",
                Name = "Rob",
                University = University.KGU
            };
            Worker person2 = new Worker
            {
                Id = "Person2",
                Name = "Nic",
                University = University.KHTI
            };
            UniversityFunc.PrintOnScreen(person0);
            UniversityFunc.PrintOnScreen(person1);
            UniversityFunc.PrintOnScreen(person2);

        
        }
    }
}
