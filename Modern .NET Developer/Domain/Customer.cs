﻿using System;
using System.Collections.Generic;

namespace Modern.NETDeveloper.Domain
{
    public class Customer
    {
        private decimal _balance;
        private ISystemClock _systemClock;
        private bool _isBonusPaid;

        public Customer(string nickname, DateTime dateOfBirth, string email, DateTime joinDate, ISystemClock systemClock)
        {
            Nickname = nickname;
            DateOfBirth = dateOfBirth;
            Email = email;
            JoinDate = joinDate;
            
            _systemClock = systemClock;
        }

        public string Nickname { get; private set; }
        public DateTime DateOfBirth { get; private set; }
        public string Email { get; private set; }
        public DateTime JoinDate { get; private set; }

        public void Deposit(decimal amount)
        {
            _balance += amount;
            
            if (!_isBonusPaid && _systemClock.Today().AddYears(-2) > JoinDate)
            {
                _balance += 50;
            }
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