using System;
using System.Collections.Generic;

namespace Modern.NETDeveloper.Domain
{
    public class Customer
    {
        private decimal _balance;

        public Customer(string nickname, DateTime dateOfBirth, string email)
        {
            Nickname = nickname;
            DateOfBirth = dateOfBirth;
            Email = email;
        }

        public string Nickname { get; private set; }
        public DateTime DateOfBirth { get; private set; }
        public string Email { get; private set; }

        public void Deposit(decimal amount)
        {
            _balance += amount;
        }

        public decimal GetBanalce()
        {
            return _balance;
        }

        public void Withdraw(decimal amount)
        {
            if (_balance < amount)
                throw new InsufficientFundsException();

            _balance -= amount;
        }
    }
}