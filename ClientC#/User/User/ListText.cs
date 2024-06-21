using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace User
{
    // Classe temporanea per il la lista del combobx
    public class ListText
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public string Edition { get; set; }
        public string Isbn { get; set; }
        public string Words { get; set; }

        public ListText(string title, string author, string edition, string isbn, string words)
        {
            this.Title = title;
            this.Author = author;
            this.Edition = edition;
            this.Isbn = isbn;
            this.Words = words;

        }
    }
}
