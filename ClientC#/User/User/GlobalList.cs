using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace User
{
    class GlobalList
    {
        public static List<Text> TextList { get; private set; }

        static GlobalList()
        {
            TextList = new List<Text>();
        }
        
        public static void Add(Text t)
        {
            TextList.Add(t);
        }

        public static void SortTextListByTitle()
        {
            TextList.Sort((x, y) => string.Compare(x.Title, y.Title));
        }
    }
}
