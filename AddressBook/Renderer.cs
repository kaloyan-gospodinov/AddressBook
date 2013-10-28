using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBook
{
    class Renderer
    {
        public StringBuilder buffer;

        public Renderer()
        {
            this.buffer = new StringBuilder();
        }

        public void RenderToConsole()
        {
            Console.Clear();
            Console.WriteLine(this.buffer.ToString());
        }

        public void RenderToConsole<T>(List<T> page) where T : class
        {
            Console.Clear();
            foreach (var item in page)
            {
                this.buffer.Append(item.ToString());
            }
        }
    }
}
