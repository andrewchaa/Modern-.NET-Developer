using System;
using Com.ThoughtWorks.TDD;
using Modern.NETDeveloper.Domain;
using Moq;
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
        public void AMessageIsSentToTheCustomerWhoWasAddedToTheBankImplementedWithStub()
        {
            var customer = _bank.AddCustomer("Andy", new DateTime(1981, 1, 1), "andy@gmail.com");

            Assert.That(_messageGateWayStub.Recipient, Is.EqualTo(customer.Email));
            Assert.That(_messageGateWayStub.Content, Is.EqualTo("Dear Andy, welcome to the bank."));
        }

        [Test]
        public void AMessageIsSentToTheCustomerWhoWasAddedToTheBankImplementeWithMock()
        {
            string expectedRecipient = "andy@gmail.com";
            string expectedContent = "Dear Andy, welcome to the bank.";

            var mockGateway = new Mock<MessageGateway>();
            mockGateway.Setup(x => x.Send(expectedRecipient, expectedContent));

            var bank = new Bank(new EmptyNicknameValidator(), new DuplicatedNicknameValidator(), mockGateway.Object);
            var customer = bank.AddCustomer("Andy", new DateTime(1981, 1, 1), "andy@gmail.com");

            mockGateway.VerifyAll();
        }

        [Test]
        public void TheJoiningDateIsSetToTodaysDateAsSoonAsTheyAreAddedToTheBank()
        {
            var bank = BankBuilder.Build();
            var customer = bank.AddCustomer("Hannah", new DateTime(1981, 1, 1), "hannah@gmail.com");

            Assert.That(customer.JoinDate, Is.EqualTo(DateTime.Today));
        }

        [Test]
        public void TheBonusIsAddedAfterTheTwoYearPeriodPasswedAndWhenCustomersMakeADeposit()
        {
            var bank = BankBuilder.Build();
            var customer = bank.AddCustomer("Hannah", new DateTime(1981, 1, 1), "hannah@gmail.com");
            customer.Deposit(100);

            // times passes

            customer.Deposit(100);
            Assert.That(customer.GetBanalce(), Is.EqualTo(200 + 50));

        }
            
    }

    public class BankBuilder
    {
        public static Bank Build()
        {
            return new Bank(new EmptyNicknameValidator(), new DuplicatedNicknameValidator(), 
                new Mock<MessageGateway>().Object);
        }
    }
}
