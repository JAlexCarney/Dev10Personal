namespace StatelessUnitTestExercises
{
    public class Exercise04
    {
        // TESTING AN INSTANCE
        // (testing non-static methods)

        // 1. Read the CalculateTotalCost docs.
        // 2. Review Exercise04Test.
        // 3. Implement CalculateTotalCost.
        // 4. Tests are incomplete. Complete them to verify all scenarios.


        /// <summary>
        /// Calculates the cost to the customer give an item price and the quantity purchased
        /// Negative price or quantity results in 0.0 cost.
        /// 1 - 15 items: no discount
        /// 16 - 25 items: 5% discount
        /// 26 - 50 items: 10% discount
        /// 51 - 75 items: 15% discount
        /// Greater than 75 items: 22% discount
        /// </summary>
        /// <param name="price">the price of a single item</param>
        /// <param name="quantity">the number of items to purchase</param>
        /// <returns>the total cost with volume discounts applied</returns>
        public double CalculateTotalCost(double price, int quantity)
        {
            if (quantity < 15)
            {
                return price * quantity;
            }
            else if(quantity < 25)
            {
                return price * quantity * 0.95;
            }
            else if (quantity < 50)
            {
                return price * quantity * 0.90;
            }
            else if (quantity < 75)
            {
                return price * quantity * 0.85;
            }
            else 
            {
                return price * quantity * 0.78;
            }
        }
    }
}
