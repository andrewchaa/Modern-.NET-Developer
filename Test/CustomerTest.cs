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
            Customer customer = GetCustomer();

            customer.Deposit(100);
            decimal balance = customer.GetBanalce();

            Assert.That(balance, Is.EqualTo(100));
        }

        private Customer GetCustomer()
        {
            var bank = new Bank(new EmptyNicknameValidator(), new DuplicatedNicknameValidator());
            return bank.AddCustomer("Andy", new DateTime(1981, 01, 01));
        }

        [Test]
        public void ShouldWithdrawFromTheBalance()
        {
            var customer = GetCustomer();

            customer.Deposit(200);
            customer.Withdraw(50);
            decimal balance = customer.GetBanalce();

            Assert.That(balance, Is.EqualTo(150));
        }
    }
}
