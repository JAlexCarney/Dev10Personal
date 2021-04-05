using System;
using System.Collections.Generic;
using System.Text;

namespace InterfaceExercises
{
    /// <summary>
    /// IMoneyStorage defines a type that can store money.
    /// </summary>
    interface IMoneyStorage
    {
        /// <summary>
        /// the current storage balance
        /// </summary>
        decimal Balance { get; }

        /// <summary>
        /// description of the IMoneyStorage
        /// </summary>
        string Description { get; }

        /// <summary>
        /// Adds to the Balance.
        /// </summary>
        /// <param name="amount">money to add to the balance.</param>
        /// <returns>true if the deposit was successful, false if not.</returns>
        bool Deposit(decimal amount);

        /// <summary>
        /// Substracts from the Balance and return the amount withdrawn.
        /// May not be the full parameter amount if rules doesn't allow it.
        /// </summary>
        /// <param name="amount">money to remove from the balance.</param>
        /// <returns>the amount of money successfully withdrawn.</returns>
        decimal Withdraw(decimal amount);
    }
}
