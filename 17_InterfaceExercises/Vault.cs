using System;
using System.Collections.Generic;
using System.Text;

namespace InterfaceExercises
{
    class Vault : IMoneyStorage
    {
        private decimal balance;
        private string description;

        public decimal Balance => balance;
        public string Description => description;

        public Vault(decimal startingBalance, string description) 
        {
            balance = startingBalance;
            this.description = description;
        }

        public bool Deposit(decimal amount) 
        {
            if (amount > decimal.Zero) 
            {
                balance += amount;
                return true;
            }
            return false;
        }

        public decimal Withdraw(decimal amount) 
        {
            if (amount <= decimal.Zero) 
            {
                return decimal.Zero;
            }

            decimal result = Math.Min(amount, balance);
            balance -= result;
            return result;
        }
    }
}
