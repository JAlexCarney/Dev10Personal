using System;
using System.Collections.Generic;
using System.Text;

namespace InterfaceExercises
{
    /// <summary>
    ///  A Wallet stores money.
    ///  All positive deposits are allowed.
    ///  Withdraws are allowed up to the balance.
    /// </summary>
    class Wallet : IMoneyStorage
    {

        private decimal balance;
        private string description;

        public decimal Balance => balance;

        public string Description => description;


        public Wallet(decimal startingBalance, string description)
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

            decimal result = Math.Min(amount, balance);
            balance -= result;
            return result;
        }
    }
}
