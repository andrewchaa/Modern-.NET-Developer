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
            var bank = new Bank(new EmptyNicknameValidator(), new DuplicatedNicknameValidator());
            var customer = bank.AddCustomer("andy", new DateTime(1971, 1, 1));

            Assert.That(customer, Is.Not.Null);
        }

        [Test]
        public void ShouldReturnNullIfNicknameIsNull()
        {
            var bank = new Bank(new EmptyNicknameValidator(), new DuplicatedNicknameValidator());
            var customer = bank.AddCustomer(null, new DateTime(1971, 1, 1));

            Assert.That(customer, Is.Null);
        }
    }
}
