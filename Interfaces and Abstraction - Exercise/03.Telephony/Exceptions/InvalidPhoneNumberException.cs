using System;
using System.Collections.Generic;
using System.Text;

namespace _03.Telephony.Exceptions
{
    public class InvalidPhoneNumberException : Exception
    {
        private const string INVALID_NUMBER_EXC_MSG = "Invalid number!";

        public InvalidPhoneNumberException()
            : base(INVALID_NUMBER_EXC_MSG)
        {

        }
    }
}
