using NUnit.Framework;
using StatefulUnitTestExercises.Commerce;

namespace StatefulUnitTestExercises.Tests.Commerce
{
    public class OrderTest
    {
        Order order = new Order(25);

        [Test]
        public void ShouldHaveOrderId()
        {
            Assert.AreEqual(25, order.OrderId);
        }

        [Test]
        public void ShouldAddValidItems()
        {
            LineItem grassSeed = new LineItem("Grass Seed", 19.99M, 2);
            bool result = order.Add(grassSeed);
            Assert.IsTrue(result);
            Assert.AreEqual(1, order.LineItems.Count);
            Assert.AreEqual(grassSeed, order.LineItems[0]);

            LineItem gardenRake = new LineItem("Garden Rake", 44.99M, 1);
            result = order.Add(gardenRake);
            Assert.IsTrue(result);
            Assert.AreEqual(2, order.LineItems.Count);
            Assert.AreEqual(gardenRake, order.LineItems[1]);

            LineItem hose = new LineItem("Garden Hose - 50ft", 38.49M, 1);
            result = order.Add(hose);
            Assert.IsTrue(result);
            Assert.AreEqual(3, order.LineItems.Count);
            Assert.AreEqual(hose, order.LineItems[2]);
        }

        // 1. Add test ShouldNotAddInvalidItems: confirm that it's not possible to add items with <= 0 quantity or < 0 price.
        // 2. Test the order.Total in various scenarios and confirm it's correct.
        // 3. If you tackle `order.Remove`, test the method thoroughly.

    }
}