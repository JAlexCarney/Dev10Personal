using System.Collections.Generic;

namespace StatefulUnitTestExercises.Commerce
{
    /// <summary>
    /// An informal sale contract for purchasable products and services.
    /// Products and services are modeled as LineItems.
    /// They're added to the order one at a time with the `Add` method.
    /// </summary>
    public class Order
    {
        // protected state
        private readonly int orderId;
        private List<LineItem> lineItems = new List<LineItem>();

        public int OrderId => orderId;
        public List<LineItem> LineItems => new List<LineItem>(lineItems);

        public decimal Total
        {
            get
            {
                // 1. Complete the Total property.
                // It should calculate the order's grand total by summing totals from each LineItem.
                return decimal.Zero;
            }
        }

        public Order(int orderId)
        {
            this.orderId = orderId;
        }

        public bool Add(LineItem lineItem)
        {
            // invalid item
            if(lineItem == null || lineItem.Quantity <= 0M || lineItem.Price < 0.0M)
            {
                return false;
            }

            lineItems.Add(lineItem);
            return true;
        }

        // 2. Stretch goal: add a Remove method that removes a LineItem by either index or reference.
    }
}
