using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AddressBook
{
    public class AreaPhoneCode : PhoneCode
    {
        private short areaCode;
        private string areaName;

        public AreaPhoneCode(short areaCode, string areaName)
            : base()
        {
            this.areaCode = areaCode;
            this.areaName = areaName;
        }

        public short AreaCode
        {
            get
            {
                return this.areaCode;
            }
            private set
            {
                if (value < 1 || value > 2000)
                {
                    throw new ArgumentOutOfRangeException("Area code has to be in the range [1,2000].");
                }
                this.areaCode = value;
            }
        }

        public string AreaName
        {
            get
            {
                return this.areaName;
            }
            private set
            {
                this.areaName = StringChecker.NameCheck(value, this.areaName);
            }
        }

        public override string ToString()
        {
            return String.Format("Area Code:{0}, Area Name:{1}", areaCode, areaName);
        }
    }
}
