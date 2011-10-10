using System;
using System.Collections.Generic;
using Com.ThoughtWorks.TDD;

namespace Modern.NETDeveloper.Domain
{
    public class Bank
    {
        private readonly IList<Customer> _customers;
        private readonly IList<string> _nicknames;
        private readonly INicknameValidator _emptyNicknameValidator;
        private readonly IDuplicatedNicknameValidator _duplicatedNicknameValidator;
        private MessageGateway _messageGateway;

        public Bank(INicknameValidator emptyNicknameValidator, IDuplicatedNicknameValidator duplicatedNicknameValidator, MessageGateway messageGateway)
        {
            _emptyNicknameValidator = emptyNicknameValidator;
            _duplicatedNicknameValidator = duplicatedNicknameValidator;
            _messageGateway = messageGateway;

            _customers = new List<Customer>();
            _nicknames = new List<string>();
        }

        public Customer AddCustomer(string nickname, DateTime dateOfBirth, string email)
        {
            if (!_emptyNicknameValidator.Validate(nickname))
                return null;

            if (!_duplicatedNicknameValidator.Validate(nickname, _nicknames))
                return null;
           
            var newCustomer = new Customer(nickname, dateOfBirth, email);
            _customers.Add(newCustomer);

            _messageGateway.Send(newCustomer.Nickname, string.Format("Dear {0}, welcome to the bank.", newCustomer.Nickname));

            return newCustomer;
        }

    }
}
