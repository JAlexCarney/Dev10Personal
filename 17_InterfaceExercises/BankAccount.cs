using System;
using System.Collections.Generic;
using System.Text;

namespace InterfaceExercises
{
    class BankAccount : IMoneyStorage
    {
        private decimal balance;
        private string description;

        public decimal Balance => balance;

        public string Description => description;


        public BankAccount(decimal startingBalance, string description)
        {
            this.balance = startingBalance;
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
            // can't withdraw a negative amount
            if (amount <= decimal.Zero)
            {
                return decimal.Zero;
            }

            decimal result = balance - amount;
            if (result > -25M)
            {
                balance -= amount;
                return amount;
            }
            return balance;
        }
    }
}
