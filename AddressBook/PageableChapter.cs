using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AddressBook
{
    public class PageableChapter<T> : Chapter, IPageable<T> where T : class
    {
        protected List<T> content;

        protected PageableChapter(string header, byte size)
            : base(header,size)
        {
        }

        public List<T> Content
        {
            get
            {
                return new List<T>(this.content);
            }
        }

        public override bool AddContent(object addedContent)
        {
            T newContent = addedContent as T;
            if ((object)newContent != null)
            {
                this.content.Add(newContent);

                this.UpdateSize();

                return true;
            }
            return false;
        }

        
        private void UpdateSize()
        {
            int remainder = this.content.Count / Chapter.PageSize;
            if (remainder == 1)
            {
                this.Size++;
            }
        }

        public List<T> NextPage()
        {
            List<T> nextPage = new List<T>();
            int nextPageStart;
            int nextPageEnd;

            if (this.CurrentPage != this.Size)
            {
                nextPageStart = this.CurrentPage * Chapter.PageSize;
            }
            else
            {
                nextPageStart = 0;
            }

            nextPageEnd = nextPageStart + Chapter.PageSize;

            for (int i = nextPageStart; i < nextPageEnd; i++)
            {
               if (this.content[i] == null)
                {
                    break;
                }
                nextPage.Add(this.content[i]);
            }

            return nextPage;
        }

        public List<T> PreviousPage()
        {
            List<T> previousPage = new List<T>();
            int previousPageStart;
            int previousPageEnd;

            if (this.CurrentPage != 1)
            {
                previousPageStart = (this.CurrentPage - 1) * Chapter.PageSize;
            }
            else
            {
                previousPageStart = (this.Size - 1) * Chapter.PageSize;
            }

            previousPageEnd = previousPageStart + Chapter.PageSize;

            for (int i = previousPageStart; i < previousPageEnd; i++)
            {
                if (this.content[i] == null)
                {
                    break;
                }
                previousPage.Add(this.content[i]);
            }

            return previousPage;
        }

        public List<T> SkipToPage(byte pageNumber)
        {
            if (pageNumber < 0 || pageNumber > this.Size)
            {
                return new List<T>();
            }

            List<T> chosedToPage = new List<T>();
            int chosedPageStart;
            int chosedPageEnd;


            chosedPageStart = (pageNumber - 1) * Chapter.PageSize;
            chosedPageEnd = chosedPageStart + Chapter.PageSize;

            for (int i = chosedPageStart; i < chosedPageEnd; i++)
            {
                if (this.content[i] == null)
                {
                    break;
                }
                chosedToPage.Add(this.content[i]);
                
            }

            return chosedToPage;
        }

        public virtual List<T> ShowFirstPage()
        {
            List<T> firstPage = new List<T>();
            for (int i = 0; i < Chapter.PageSize; i++)
			{
                firstPage.Add(this.content[i]);
			}

            return firstPage;
        }
    }
}
