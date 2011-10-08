using System;
using NUnit.Framework;
using Modern.NETDeveloper.Domain;

namespace Test
{
    [TestFixture]
    public class CustomerTest
    {
        [Test]
        public void ShouldDepositMoneyAndSeeItReflectInTheBalance()
        {
            var bank = new Bank(new EmptyNicknameValidator(), new DuplicatedNicknameValidator());
            var customer = bank.AddCustomer("Andy", new DateTime(1981, 01, 01));

            customer.Deposit(100);
            decimal balance = customer.GetBanalce();

            Assert.That(balance, Is.EqualTo(100));
        }
    }
}
