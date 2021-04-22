namespace StatelessUnitTestExercises
{
    public class Exercise01
    {

        // INTEGER MATH

        // The following methods reimplement math operations.
        // Add == +, Subtract == -, Multiply == *, Divide == /
        // Parameters are operands that should be applied in order.
        // For example: a + b, not b + a.

        // 1. Open Exercise01Test in the StatelessUnitTestExercises.Tests project and run all tests.
        // 2. Complete the Add and Subtract methods and make all tests pass.

        public static int Add(int a, int b)
        {
            return a + b;
        }

        public static int Subtract(int a, int b)
        {
            return a - b;
        }

        // 3. Add tests for Multiply and Divide in Exercise01Test.
        // Provide at least 6 test cases.
        // 4. Run all tests.
        // 5. Complete the Multiply and Divide methods and make all tests pass.

        public static int Multiply(int a, int b)
        {
            return a * b;
        }

        public static int Divide(int a, int b)
        {
            return a / b;
        }
    }
}
