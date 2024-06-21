using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace User
{
    class Text
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string Edition { get; set; }
        public string Isbn { get; set; }
        public string Words { get; set; }

        public Text(string title, string author, string edition, string isbn, string words)
        {
            this.Id = title + " - edition " + edition;
            this.Title = title;
            this.Author = author;
            this.Edition = edition;
            this.Isbn = isbn;
            this.Words = words;

            GlobalList.Add(this);
        }
    }
}
