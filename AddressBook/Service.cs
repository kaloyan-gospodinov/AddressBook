using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AddressBook
{
    public struct Service
    {
        private int code;
        private uint price;

        private static int serviceCounter = 1;

        public Service(uint price)
        {
            this.code = Service.serviceCounter;
            this.price = price;
            Service.serviceCounter++;
        }

        public int Code
        {
            get
            {
                return this.code;
            }
        }

        public uint Price
        {
            get
            {
                return this.price;
            }
        }
    }
}
