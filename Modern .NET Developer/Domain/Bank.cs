using System;
using System.Collections.Generic;

namespace Modern.NETDeveloper.Domain
{
    public class Bank
    {
        private readonly IList<Customer> _customers;
        private readonly IList<string> _nicknames;
        private readonly INicknameValidator _emptyNicknameValidator;
        private readonly IDuplicatedNicknameValidator _duplicatedNicknameValidator;

        public Bank(INicknameValidator emptyNicknameValidator, IDuplicatedNicknameValidator duplicatedNicknameValidator)
        {
            _emptyNicknameValidator = emptyNicknameValidator;
            _duplicatedNicknameValidator = duplicatedNicknameValidator;

            _customers = new List<Customer>();
            _nicknames = new List<string>();
        }

        public Customer AddCustomer(string nickname, DateTime dateOfBirth)
        {
            if (!_emptyNicknameValidator.Validate(nickname))
                return null;

            if (!_duplicatedNicknameValidator.Validate(nickname, _nicknames))
                return null;
           
            var newCustomer = new Customer(nickname, dateOfBirth);
            _customers.Add(newCustomer);

            return newCustomer;
        }

    }
}
