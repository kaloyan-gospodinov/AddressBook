using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AddressBook
{
    public class Codes<T> : PageableChapter<T> where T : class
    {
        public Codes(string header, byte size = 1)
            : base(header,size)
        {
            this.content = new List<T>();
        }
    }
}
