using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBook
{
    class NotANameException : Exception
    {
        public NotANameException(string msg)
        : base(msg)
        { }

        public NotANameException(string msg,
        Exception innerEx) : base(msg, innerEx)
        { }
    }
}
