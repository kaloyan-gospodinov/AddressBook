using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AddressBook
{
    public class ABEngine
    {
        KeyboardInterface userInterface;
        Renderer renderer;
        AddressBook book;

        public ABEngine()
        {
            this.renderer = new Renderer();
            this.book = new AddressBook();
            this.userInterface = new KeyboardInterface();
        }

        public void EventNextPage()
        {
            this.renderer.buffer.Clear();
            this.renderer.buffer.Append(this.book.Chapters[this.book.CurrentChapter].NextPage());
        }

        public void EventPreviousPage()
        {
            this.renderer.buffer.Clear();
            this.renderer.buffer.Append(this.book.Chapters[this.book.CurrentChapter].PreviousPage());
        }

        public void EventSkipToPage()
        {
            this.renderer.buffer.Clear();
            byte page = byte.Parse(Console.ReadLine());
            this.renderer.buffer.Append(this.book.Chapters[this.book.CurrentChapter].SkipToPage(page));
        }

        public void ChangeChapter()
        {
            this.renderer.buffer.Clear();
            this.renderer.buffer.Append(this.book.Summary);
            this.book.currentChapter = int.Parse(Console.ReadLine());
        }

        public void Run()
        {
            this.renderer.buffer.Append(this.book.Summary);

            this.renderer.RenderToConsole();

            this.book.currentChapter = int.Parse(Console.ReadLine());

            Console.Clear();

            this.renderer.RenderToConsole(this.book.Chapters[this.book.CurrentChapter].ShowFirstPage());
            
            while (true)
            {
                this.renderer.RenderToConsole();
            }
        }
    }
}
