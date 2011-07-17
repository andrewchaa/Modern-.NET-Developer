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
        }

        public Customer AddCustomer(string nickname, DateTime dateOfBirth)
        {
            if (string.IsNullOrEmpty(nickname))
                return null;

            if (_nicknames.Contains(nickname))
                return null;
           
            var newCustomer = new Customer(nickname, dateOfBirth);
            _customers.Add(newCustomer);

            return newCustomer;
        }

    }
}
