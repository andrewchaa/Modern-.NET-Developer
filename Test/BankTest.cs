using System;
using Modern.NETDeveloper.Domain;
using NUnit.Framework;

namespace Test
{
    [TestFixture]
    public class BankTest
    {
        [Test]
        public void ShouldAddCustomerNickname()
        {
            var bank = new Bank();
            var customer = bank.AddCustomer("andy", new DateTime(1971, 1, 1));

            Assert.That(customer, Is.Not.Null);
        }
    }
}
