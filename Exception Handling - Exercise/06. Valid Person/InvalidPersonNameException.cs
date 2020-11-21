using System;
using System.Collections.Generic;
using System.Text;

namespace _06._Valid_Person
{
    class InvalidPersonNameException : Exception
    {
        public InvalidPersonNameException(string msg) 
            : base(msg)
        {

        }
    }
}
