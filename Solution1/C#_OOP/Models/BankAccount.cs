using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace C__OOP.Models
{
    public class BankAccount
    {
        private decimal _balance;
        public decimal Balance { get { return _balance; } }
        public string Owner { get; set; }

        public BankAccount(decimal balance, string owner)
        {
            _balance=balance;
            Owner= owner;
        }

        public void Deposite(decimal ammount)
        {
            if(ammount <= 0)
            {
                Console.WriteLine("ammount should be more than zero");
            }

            _balance += ammount;
        }
        public void Withdraw(decimal ammount)
        {
            if (ammount <= 0)
            {
                Console.WriteLine("ammount should be more than zero");
            }
            if (ammount > _balance)
            {
                Console.WriteLine("insufficient balance available");
            }

            _balance -= ammount;
        }
        public virtual string GetAccountType()
        {
            return "Standard";
        }

    }
}
