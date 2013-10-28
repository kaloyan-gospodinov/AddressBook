using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AddressBook
{
    public abstract class Chapter
    {
        private string header;
        private byte size;
        private int currentPage;

        public const byte PageSize = 5;

        protected Chapter(string header, byte size = 1 )
        {
            this.Header = header;
            this.size = size;
            this.currentPage = 0;
        }

        public virtual string Header
        {
            get
            {
                return this.header;
            }
            protected set
            {
                if (value == null)
                {
                    throw new NotANameException("Header cannot be empty.");
                }
                if (value.Length < 2 || value.Length > 255)
                {
                    throw new NotANameException("Header cannot exceed 255 symbols or be less than 2 symbols.", new FormatException());
                }
                this.header = value;
            }
        }

        protected virtual byte Size
        {
            get
            {
                return this.size;
            }
            set
            {
                this.size = value;
            }
        }

        protected virtual int CurrentPage
        {
            get
            {
                return this.currentPage;
            }
            set
            {
                if (value != 0)
                {
                    if (value < 0)
                    {
                        if (this.currentPage + value < 0)
                        {
                            this.currentPage = 1;
                        }
                    }
                    else
                    {
                        if (this.currentPage + value > this.Size)
                        {
                            this.currentPage = this.Size;
                        }
                    }
                }
            }
        }
        public abstract bool AddContent(object content);
    }
}
