using System;
using Modern.NETDeveloper.Domain;
using NUnit.Framework;

namespace Test
{
    [TestFixture]
    public class BankTest
    {
        private Bank _bank;
        private MessageGatewayStub _messageGateWayStub;

        [SetUp]
        public void SetUp()
        {
            _messageGateWayStub = new MessageGatewayStub();
            _bank = new Bank(new EmptyNicknameValidator(), new DuplicatedNicknameValidator(), _messageGateWayStub);
        }

        [Test]
        public void ShouldAddCustomerNickname()
        {
            var customer = _bank.AddCustomer("andy", new DateTime(1971, 1, 1), "andy@gmail.com");

            Assert.That(customer, Is.Not.Null);
        }

        [Test]
        public void ShouldReturnNullIfNicknameIsNull()
        {
            var customer = _bank.AddCustomer(null, new DateTime(1971, 1, 1), "andy@gmail.com");

            Assert.That(customer, Is.Null);
        }

        [Test]
        public void ShouldPopulateCustomerWhenRegistrationIsDone()
        {
            var customer = _bank.AddCustomer("Andy", new DateTime(1981, 1, 1), "andy@gmail.com");

            Assert.That(customer.Nickname, Is.EqualTo("Andy"));
            Assert.That(customer.DateOfBirth, Is.EqualTo(new DateTime(1981, 1, 1)));
            Assert.That(customer.Email, Is.EqualTo("andy@gmail.com"));
        }

        [Test]
        public void AMessageIsSentToTheCustomerWhoWasAddedToTheBank()
        {
            var customer = _bank.AddCustomer("Andy", new DateTime(1981, 1, 1), "andy@gmail.com");

            Assert.That(_messageGateWayStub.Recipient, Is.EqualTo(customer.Nickname));
            Assert.That(_messageGateWayStub.Content, Is.EqualTo("Dear Andy, welcome to the bank."));
        }
    }
}
