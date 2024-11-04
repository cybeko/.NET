using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace hw18_delegate
{
    public class CreditCard
    {
        public string CardNumber { get; set; }
        public string FullName { get; set; }
        public string PIN { get; set; }
        public DateOnly ExpirationDate { get; set; }
        public int CreditLimit { get; set; }
        public int CurrentAmount { get; set; }

        public event Action<int>? MoneyDeposited;
        public event Action<int>? MoneyWithdrawn;
        public event Action? CreditUsed;
        public event Action? MoneyGoalReached;
        public event Action? PinChanged;

        public CreditCard(string cardNumber, string fullName, string pin, DateOnly expirationDate, int creditLimit, int currentAmount)
        {
            CardNumber = cardNumber;
            FullName = fullName;
            PIN = pin;
            ExpirationDate = expirationDate;
            CreditLimit = creditLimit;
            CurrentAmount = currentAmount;
        }
        public void PrintCard()
        {
            Console.WriteLine("Credit card info:");
            Console.WriteLine($"Card number: {CardNumber}");
            Console.WriteLine($"Owner full name: {FullName}");
            Console.WriteLine($"Expiration date: {ExpirationDate:MM/dd/yyyy}");
            Console.WriteLine($"Credit limit: {CreditLimit}");
            Console.WriteLine($"Current balance: {CurrentAmount}");
            Console.WriteLine();
        }
        public void PutMoney(int sum)
        {
            CurrentAmount += sum;
            MoneyDeposited?.Invoke(sum);
        }
        public void WithdrawMoney(int sum)
        {
            if (CurrentAmount + CreditLimit >= sum)
            {
                CurrentAmount -= sum;
                MoneyWithdrawn?.Invoke(sum);
                if (CurrentAmount < 0)
                    CreditUsed?.Invoke();
            }
            else
            {
                Console.WriteLine("Not enough money.");
            }
        }

        public void ChangePin(string newPin)
        {
            PIN = newPin;
            PinChanged?.Invoke();
        }

        public void CheckMoneyGoal(int goal)
        {
            if (CurrentAmount >= goal)
                MoneyGoalReached?.Invoke();
        }
    }
    public class CreditCardMessage
    {
        public void Subscribe(CreditCard obj)
        {
            obj.MoneyDeposited += OnMoneyDeposited;
            obj.MoneyWithdrawn += OnMoneyWithdrawn;
            obj.CreditUsed += OnCreditUsed;
            obj.MoneyGoalReached += OnMoneyGoalReached;
            obj.PinChanged += OnPinChanged;
        }

        private void OnMoneyDeposited(int sum)
        {
            Console.WriteLine($"Replenished amount: {sum}");
        }

        private void OnMoneyWithdrawn(int sum)
        {
            Console.WriteLine($"Withdrawn: {sum}");
        }

        private void OnCreditUsed()
        {
            Console.WriteLine("Using credit money");
        }

        private void OnMoneyGoalReached()
        {
            Console.WriteLine("Money goal reached");
        }

        private void OnPinChanged()
        {
            Console.WriteLine("Pin changed");
        }
    }
}
