using System;
using System.Collections.Generic;
using System.Text;

namespace InterfaceExercises
{
    /// <summary>
    ///  Mortgage starts with a negative balance.
    ///  Positive deposits pay down the loan.
    ///  Withdraws are ignored.
    /// </summary>
    class Mortgage : IMoneyStorage
    {
        private decimal balance;
        private string accountNumber;

        public decimal Balance => balance;

        public string Description => $"Mortgage #{accountNumber}";

        public string AccountNumber => accountNumber;

        public Mortgage(decimal startingBalance, string accountNumber)
        {
            this.balance = -startingBalance;
            this.accountNumber = accountNumber;
        }

        public bool Deposit(decimal amount)
        {
            if (amount <= decimal.Zero)
            {
                return false;
            }
            balance = Math.Min(decimal.Zero, balance + amount);
            return true;
        }

        public decimal Withdraw(decimal amount)
        {
            // can't withdraw from a mortgage
            return decimal.Zero;
        }
    }
}
