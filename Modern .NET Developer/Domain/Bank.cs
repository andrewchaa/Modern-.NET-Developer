using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Modern.NETDeveloper.Domain
{
    public class Bank
    {
        private IList<Customer> _customers;
        private IList<string> _nicknames;

        public Bank()
        {
            _customers = new List<Customer>();
            _nicknames = new List<string>();
        }

        public Customer AddCustomer(string nickname, DateTime dateOfBirth)
        {
            var nicknameValidator = new NicknameValidator();
            if (!nicknameValidator.Validate(nickname))
                return null;

            if (!ValidateDuplicatedNickname(nickname))
                return null;
           
            var newCustomer = new Customer(nickname, dateOfBirth);
            _customers.Add(newCustomer);

            return newCustomer;
        }

        private bool ValidateDuplicatedNickname(string nickname)
        {
            return !_nicknames.Contains(nickname);
        }

    }

    public class NicknameValidator
    {
        public bool Validate(string nickname)
        {
            return !string.IsNullOrEmpty(nickname);
        }
    }
}
