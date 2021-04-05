using System;

namespace InterfaceExercises
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // COMPOSITION vs. INHERITANCE

            /* Take a look inside the Person class.
            The initial developer made an interesting design decision. In order to allow payment to a Person, they made
            the Person class extend Wallet. Currently, a Person is-a Wallet. While it sort of works - we can give a Person
            money via the `Deposit` method and ask for money via `Withdraw` - it's a little strange. A Person isn't truly
            a Wallet. A Person has-a Wallet.
             */

            // 1. Refactor the Person class so that it no longer extends Wallet. Instead, solve the problem using
            // composition - a has-a relationship. Person should have a Wallet field or property.
            // 2. While you're at it, change the Wallet field or property to the more generic IMoneyStorage.
            // Person may optionally have an IMoneyStorage.

            Person p = new Person("Sidonnie", "Antonietti");
            p.Deposit(125.85M);
            Console.WriteLine(p.FullName);
            Console.WriteLine(p.Description);
            Console.WriteLine(p.Balance);
        }
    }
}
