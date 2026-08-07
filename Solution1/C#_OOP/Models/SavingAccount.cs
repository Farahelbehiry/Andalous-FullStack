using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C__OOP.Models
{
    internal class SavingAccount : BankAccount
    {
        public decimal InterestRate;

        public SavingAccount(decimal balance, string owner,decimal interestRate):base(balance, owner)
        {
            InterestRate = interestRate;
        }
        public void ApplyInterest()
        {
            Deposite(Balance * InterestRate);

        }

        public override string GetAccountType()
        {
            return "Saving";
        }
    }
}
