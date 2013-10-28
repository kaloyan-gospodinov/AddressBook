using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBook
{
    static class StringChecker
    {
        public static string NameCheck(string value, string field, short minLength = 2, short maxLength = 255)
        {
            if (value == null)
            {
                throw new NotANameException(field + "name cannot be empty.");
            }
            if (value.Length < minLength || value.Length > maxLength)
            {
                throw new NotANameException(field + " name cannot exceed " + maxLength +
                    " symbols or be less than " + minLength + " symbols.", new FormatException());
            }
            return value;
        }
    }
}
