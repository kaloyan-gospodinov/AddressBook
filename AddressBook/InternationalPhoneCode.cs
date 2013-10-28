using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AddressBook
{
    public class InternationalPhoneCode : PhoneCode
    {
        private string isoCountryCode;
        private string countryName;
        private int countryPhoneCode;

        public InternationalPhoneCode(string isoCountryCode, string countryName)
            : base()
        {
            this.isoCountryCode = isoCountryCode;
            this.countryName = countryName;
        }

        public string IsoCountryCode
        {
            get
            {
                return this.isoCountryCode;
            }
            private set
            {
                this.isoCountryCode = StringChecker.NameCheck(value, this.isoCountryCode, 2, 3);
            }
        }

        public string CountryName
        {
            get
            {
                return this.countryName;
            }
            private set
            {
                this.countryName = StringChecker.NameCheck(value, this.countryName);
            }
        }

        public int CountryPhoneCode
        {
            get { return this.countryPhoneCode; }
            set
            {
                if (value < 1 || value > 2000)
                {
                    throw new ArgumentOutOfRangeException("International Phone Code has to be in the range [1,2000].");
                }
                this.countryPhoneCode = value;
            }
        }

        public override string ToString()
        {
            return String.Format("ISO Country Code:{0}, Country Name:{1}", isoCountryCode, countryName);
        }
    }
}
