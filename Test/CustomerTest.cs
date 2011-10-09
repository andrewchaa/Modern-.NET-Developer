using System;
using NUnit.Framework;
using Modern.NETDeveloper.Domain;

namespace Test
{
    [TestFixture]
    public class CustomerTest
    {
        private Customer _customer;

        [SetUp]
        public void SetUp()
        {
            var bank = new Bank(new EmptyNicknameValidator(), new DuplicatedNicknameValidator());
            _customer = bank.AddCustomer("Andy", new DateTime(1981, 01, 01), "andy@gmail.com");
        }

        [Test]
        public void CanDepositMoneyAndSeeItReflectInTheBalance()
        {
            _customer.Deposit(100);
            decimal balance = _customer.GetBanalce();

            Assert.That(balance, Is.EqualTo(100));
        }

        [Test]
        public void CanWithdrawFromTheBalance()
        {
            _customer.Deposit(200);
            _customer.Withdraw(50);
            decimal balance = _customer.GetBanalce();

            Assert.That(balance, Is.EqualTo(150));
        }

        [Test]
        public void CanWithdrawAllTheMoney()
        {
            _customer.Deposit(500);
            _customer.Withdraw(500);
            decimal balance = _customer.GetBanalce();

            Assert.That(balance, Is.EqualTo(0));
        }

        [Test]
        [ExpectedException(typeof(InsufficientFundsException))]
        public void AttemptingToOverdrawWillResultInAnExceptionBeingThrown()
        {
            _customer.Deposit(100);
            _customer.Withdraw(200);
            
        }

    }
}
