using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AddressBook
{
    public interface IPageable<T>
    {
        List<T> NextPage();
        List<T> PreviousPage();
        List<T> SkipToPage(byte pageNumber);
    }
}
