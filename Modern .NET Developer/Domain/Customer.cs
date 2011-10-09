using System;
using System.Collections.Generic;

namespace Modern.NETDeveloper.Domain
{
    public class Customer
    {
        private decimal _balance;
        private string _nickname;
        private DateTime _dateOfBirth;

        public Customer(string nickname, DateTime dateOfBirth)
        {
            _nickname = nickname;
            _dateOfBirth = dateOfBirth;
        }

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
            _balance -= amount;
        }
    }
}