using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace TestProject1
{
    [TestFixture]
    class PowerTests
    {
        [Test]
        public void PowerOfZeroReturnsOne() 
        {
            int num = 2;
            int pow = 0;

            double result = Math.Pow(num, pow);

            Assert.That(result == 1);
        }
    }
}
