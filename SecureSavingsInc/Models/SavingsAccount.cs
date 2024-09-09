using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecureSavingsInc.Models
{
    public class SavingsAccount : BankAccount
    {
        public decimal InterestRate { get; private set; }

        public SavingsAccount(string accountHolderName, decimal initialBalance, decimal interestRate)
            : base(accountHolderName, initialBalance)
        {
            InterestRate = interestRate;
        }

      
    }
}
