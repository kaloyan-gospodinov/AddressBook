using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace AddressBook
{
    public class Family : IReadable
    {
        private string familyName;
        private byte membersCount;
        private string phoneNumber;

        public Family(string fName, string pNumber, byte membersCount = 1)
        {
            this.FamilyName = fName;
            this.MembersCount = membersCount;
            this.PhoneNumber = pNumber;
        }

        public string FamilyName
        {
            get
            {
                return this.familyName;
            }
            set
            {
                this.familyName = StringChecker.NameCheck(value,this.familyName);
            }
        }

        public byte MembersCount
        {
            get
            {
                return this.membersCount;
            }
            set
            {
                if (value <= 0)
                {
                    throw new FormatException("Family members cannot be 0 or less");
                }
                this.membersCount = value;
            }
        }

        public string PhoneNumber
        {
            get
            {
                return this.phoneNumber;
            }
            set
            {
                Regex reg=new Regex(@"^[2-9]\d{2}-\d{3}-\d{4}$");
                if (reg.IsMatch(value))
                {
                    this.phoneNumber = value;
                }
                else
                {
                    throw new FormatException("This is not a phone a number.");
                }
            }
        }

        public override string ToString()
        {
            StringBuilder text = new StringBuilder();
            text.Append(this.familyName);
            text.Append(" family members : ");
            text.Append(this.membersCount);
            text.Append(" Phone : ");
            text.Append(this.phoneNumber);

            return text.ToString();
        }
    }
}
