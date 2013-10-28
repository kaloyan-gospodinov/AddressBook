using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBook
{
    public class AddressBook
    {
        private List<PageableChapter<IReadable>> chapters;
        private Content summary;
        public int currentChapter;

        public const int SubscribersChapterIndex = 0;
        public const int BusinessChapterIndex = 1;
        public const int CodesChapterIndex = 2;

        public AddressBook()
        {
            this.chapters = new List<PageableChapter<IReadable>>();
            this.chapters.Add(new Subscribers<IReadable>("Subscribers"));
            this.chapters.Add(new Business<IReadable>("Business Section"));
            this.chapters.Add(new Codes<IReadable>("Phone Codes"));
            this.InitializeContent();
        }

        public List<PageableChapter<IReadable>> Chapters
        {
            get
            {
                return this.chapters;
            }
        }

        public int CurrentChapter
        {
            get
            {
                return this.currentChapter;
            }
            set
            {
                this.currentChapter = value;
            }
        }

        private void InitializeContent()
        {
            this.summary = new Content(this.chapters.Count);
            for (int i = 0; i < this.chapters.Count; i++)
            {
                this.summary[i] = this.chapters[i];
            }
        }

        public Content Summary
        {
            get
            {
                return this.summary;
            }
        }
    }
       
}
