using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SecureSavingsInc.Models;
namespace SecureSavingsInc.Data
{
    public class Bank
    {
        private readonly List<BankAccount> _accounts;

        public Bank()
        {
            _accounts = new List<BankAccount>();
        }

        public void AddAccount(BankAccount account)
        {
            if (account == null)
                throw new ArgumentNullException(nameof(account));

            _accounts.Add(account);
        }

        public BankAccount FindAccount(string accountNumber)
        {
            return _accounts.FirstOrDefault(acc => acc.AccountNumber == accountNumber);
        }

        public void TransferFunds(string fromAccountNumber, string toAccountNumber, decimal amount)
        {
            var fromAccount = FindAccount(fromAccountNumber);
            var toAccount = FindAccount(toAccountNumber);

            if (fromAccount == null || toAccount == null)
                throw new InvalidOperationException("One or both accounts not found.");

            fromAccount.Transfer(toAccount, amount);
        }

       
    }
}
