using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AddressBook
{
    public class Advertisement
    {
        private string advertisementName;
        private AdsType type;
        private string advertisementText;

        public Advertisement(string advName, string advText, AdsType advType)
        {
            this.advertisementName = advName;
            this.advertisementText = advText;
            this.type = advType;
        }

        public string AdvertisementName
        {
            get
            {
                return this.advertisementName;
            }
            private set
            {
                this.advertisementName = StringChecker.NameCheck(value, this.advertisementName);
            }
        }

        public string AdvertisementText
        {
            get
            {
                return this.advertisementText;
            }
            private set
            {
                this.advertisementText = StringChecker.NameCheck(value, this.advertisementText, 10, 1000);
            }
        }

        public AdsType Type
        {
            get
            {
                return this.type;
            }
            set
            {
                this.type = value;
            }
        }
    }
}
