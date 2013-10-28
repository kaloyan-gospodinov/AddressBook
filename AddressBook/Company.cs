using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace AddressBook
{
    public class Company : IReadable
    {
        public const int CompanyIdLength = 10;

        private string companyName;
        private string companyID;
        private string companyServicePhone;
        List<Advertisement> ads;
        List<Service> services;

        public Company(string companyName, string companyID, List<Advertisement> ads, List<Service> services)
        {
            this.CompanyName = companyName;
            this.CompanyID = companyID;
            this.ads = new List<Advertisement>(ads);
            this.services = new List<Service>(services);
        }

        public string CompanyName
        {
            get
            {
                return this.companyName;
            }
            set
            {
                this.companyName = StringChecker.NameCheck(value, this.companyName);
            }
        }

        public string CompanyID
        {
            get
            {
                return this.companyID;
            }
            set
            {
                this.companyID = StringChecker.NameCheck(value, this.companyID, Company.CompanyIdLength, Company.CompanyIdLength);
            }
        }

        public string PhoneNumber
        {
            get
            {
                return this.companyServicePhone;
            }
            set
            {
                Regex reg = new Regex(@"^[2-9]\d{2}-\d{3}-\d{4}$");
                if (reg.IsMatch(value))
                {
                    this.companyServicePhone = value;
                }
                else
                {
                    throw new FormatException("This is not a phone a number.");
                }
            }
        }

        public List<Service> Services
        {
            get
            {
                return new List<Service>(this.services);
            }
        }

        public List<Advertisement> Ads
        {
            get
            {
                return new List<Advertisement>(this.ads);
            }
        }

        public override string ToString()
        {
            StringBuilder text = new StringBuilder();
            text.Append(this.companyName);
            text.Append(" ID : ");
            text.Append(this.companyID);
            text.Append(" Phone : ");

            text.AppendLine("Ads :");

            foreach (var adv in this.Ads)
            {
                this.DrawByTypeOfAdvertisement(text, adv);

                text.AppendLine();
                text.Append(adv.AdvertisementName);
                text.AppendLine();
                text.Append(adv.AdvertisementText);
                text.AppendLine();

                this.DrawByTypeOfAdvertisement(text, adv);
            }

            text.AppendLine();
            text.AppendLine("Services :");

            foreach (var service in this.Services)
            {
                text.AppendLine();
                text.Append(" Code : ");
                text.Append(service.Code);
                text.Append("  Price : ");
                text.Append(service.Price);
                text.AppendLine();
            }

            return text.ToString();
        }

        private void DrawByTypeOfAdvertisement(StringBuilder text,Advertisement adv)
        {
            switch (adv.Type)
            {
                case AdsType.VIP:
                    text.Append(new string('*', 20));
                    break;
                case AdsType.normal:
                    text.Append(new string('-',20));
                    break;
                case AdsType.free:
                    text.AppendLine();
                    break;
                case AdsType.hiddenInText:
                    // Implement
                    break;
            }
        }

    }
}
