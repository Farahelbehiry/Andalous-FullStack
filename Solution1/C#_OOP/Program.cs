using C__OOP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C__OOP
{
    internal class Program
    {
        static void Main(string[] args)
        {
            BankAccount[] bank = new BankAccount[]
            {
                new BankAccount(1000m,"Ahmed"),


                new SavingAccount(2000m, "Sara", 0.05m)

            };

            foreach (BankAccount bankAccount in bank)
            {
                Console.WriteLine(bankAccount.GetAccountType());
                Console.WriteLine(bankAccount.Balance);
            }

            // attempting to set balance from outside class eror
            //bank[0].Balance=1000m;

        }
    }
}
