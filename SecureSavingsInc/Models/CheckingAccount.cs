using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecureSavingsInc.Models
{
    public class CheckingAccount : BankAccount
    {
        public decimal OverdraftLimit { get; private set; }

        public CheckingAccount(string accountHolderName, decimal initialBalance, decimal OverdraftLimit)
            : base(accountHolderName, initialBalance)
        {
        }

        
    }
}
