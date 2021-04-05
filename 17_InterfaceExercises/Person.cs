using System;
using System.Collections.Generic;
using System.Text;

namespace InterfaceExercises
{
    class Person
    {
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string FullName => $"{FirstName} {LastName}";

        public IMoneyStorage Money { get; set; }

        public string Description { get { return Money.Description; } }
        public decimal Balance { get { return Money.Balance; } }


        public Person(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
            Money = new Wallet(0M,$"{firstName}'s Wallet");
        }

        public bool Deposit(decimal amount) 
        {
            return Money.Deposit(amount);
        }
    }
}
