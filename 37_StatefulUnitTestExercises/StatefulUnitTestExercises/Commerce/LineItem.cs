using System;

namespace StatefulUnitTestExercises.Commerce
{
    /// <summary>
    /// An product or service that's part of an Order.
    /// Could represent anything with a price and quantity.
    /// Examples:
    /// new LineItem("Grass Seed", 25.49M, 1M)
    /// new LineItem("Double Scoop Cone - Rocky Road", 5.45M, 2M)
    /// new LineItem("Technician Service (hours)", 56.75M, 8.50M)
    /// new LineItem("Movie Rental - The Muppet Movie", 1.99M, 1M)
    /// </summary>
    public class LineItem
    {
        public string ItemName { get; private set; }
        public decimal Price { get; private set; }
        public decimal Quantity { get; private set; }
        public decimal Total => Price * Quantity;

        public LineItem(string itemName, decimal price, decimal quantity)
        {
            ItemName = itemName;
            Price = price;
            Quantity = quantity;
        }

        public override bool Equals(object obj)
        {
            return obj is LineItem item &&
                   ItemName == item.ItemName &&
                   Price == item.Price &&
                   Quantity == item.Quantity &&
                   Total == item.Total;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(ItemName, Price, Quantity, Total);
        }
    }
}
