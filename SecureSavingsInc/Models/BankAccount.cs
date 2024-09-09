using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecureSavingsInc.Models
{
    public abstract class BankAccount
    {
        private static int _accountNumberGeneration = 1000;

        public string AccountNumber { get; private set; }
        public decimal Balance { get; protected set; }
        public string AccountHolderName { get; set; }

        public BankAccount(string accountHolderName, decimal initialBalance)
        {
            AccountNumber = _accountNumberGeneration.ToString();
            _accountNumberGeneration++;
            AccountHolderName = accountHolderName;
            Balance = initialBalance;
        }

        public void Deposit(decimal amount)
        {
            if (amount <= 0)
                throw new ArgumentException("Deposit amount must be positive.");

            Balance += amount;
        }

        public virtual void Withdraw(decimal amount)
        {
            if (amount <= 0)
                throw new ArgumentException("Withdrawal amount must be positive.");

            if (Balance >= amount)
            {
                Balance -= amount;
            }
            else
            {
                throw new InvalidOperationException("Insufficient funds.");
            }
        }

        public void Transfer(BankAccount toAccount, decimal amount)
        {
            if (toAccount == null)
                throw new ArgumentNullException(nameof(toAccount));

            Withdraw(amount);
            toAccount.Deposit(amount);
        }
    }
}

