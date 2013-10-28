using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AddressBook
{
    public class Business<T> : PageableChapter<T> where T : class
    {
        public Business(string header, byte size = 1)
            : base(header,size)
        {
            this.content = new List<T>();
        }
    }
}
