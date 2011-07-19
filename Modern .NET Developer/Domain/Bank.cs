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
            INicknameValidator emptyNicknameValidator = new EmptyNicknameValidator();
            if (!emptyNicknameValidator.Validate(nickname))
                return null;

            INicknameValidator duplicatedNicknameValidator = new DuplicatedNicknameValidator(_nicknames);
            if (!duplicatedNicknameValidator.Validate(nickname))
                return null;
           
            var newCustomer = new Customer(nickname, dateOfBirth);
            _customers.Add(newCustomer);

            return newCustomer;
        }

    }
}
