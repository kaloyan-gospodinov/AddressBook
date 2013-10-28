using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AddressBook
{
    public class Content
    {
        Chapter[] chapters;

        public Content(int size)
        {
            this.chapters = new Chapter[size];
        }

        public Chapter[] Chapters
        {
            get
            {
                return this.chapters;
            }
        }

        public Chapter this [int index]
        {
            get
            {
                return this.chapters[index];
            }
            set
            {
                this.chapters[index] = value;
            }
        }

        public override string ToString()
        {
            StringBuilder text = new StringBuilder();

            for (int i = 0; i < this.chapters.Length; i++)
			{
                text.AppendLine(this.chapters[i].Header + "......"+(i+1));
            }

            return text.ToString();
        }
    }
}
