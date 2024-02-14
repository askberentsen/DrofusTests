using System;
using NUnit.Framework;
using Task1.Models;

namespace TestProject1.Models
{
    [TestFixture]
    [TestOf(typeof(VendingMachine))]
    public class VendingMachineTest
    {
        private VendingMachine vendingMachine;

        [SetUp]
        public void TestInitialize()
        {
            vendingMachine = new VendingMachine();
        }
        
        // Here merely to demonstrate. I am having technical difficulties with NUnit on my computer, and i do not have the time or
        // patience to fix these issues in this short timeframe.
        // I'll gladly answer questions regarding how i would test.
        // My unit testing experience is from Java and python
        [Test]
        public void VendingMachineDoesNotAcceptMoneyIfItOverflows()
        {
            vendingMachine.AddCredit(1);

            Assert.Throws<OverflowException>(() =>
            {
                vendingMachine.AddCredit(uint.MaxValue);
            });
        }
    }
}