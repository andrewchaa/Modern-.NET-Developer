using System;

namespace Modern.NETDeveloper.Domain
{
    public class InsufficientFundsException : Exception
    {
        public override string Message
        {
            get { return "The balance is overdrawn!"; }
        }
    }
}