using System;

namespace MutiFileTesting
{
    public class Program
    {
        // 1. Create a new method in the `Hero` class.
        // Name: ToLine
        // Inputs: none
        // Output: string
        // Description: returns the Hero's name and powers as a single line of text.

        public static void Main(string[] args)
        {
            // 2. Instantiate your three favorite super heroes with appropriate powers.
            Power strength = new Power("Super Strength");
            Power healing = new Power("Healing");
            Power superSayain = new Power("Super Sayain");

            Hero allMight = new Hero("All Might", new Power[] { strength });
            Hero trunks = new Hero("Trunks Briefs", new Power[] { strength, healing, superSayain });
            Hero goku = new Hero("Goku", new Power[] { strength, superSayain });

            // 3. Use the `ToLine` method to print each hero's details to the console.
            Console.WriteLine(allMight);
            Console.WriteLine(trunks);
            Console.WriteLine(goku);
        }
    }
}
