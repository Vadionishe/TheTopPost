using System.Collections.Generic;

namespace TheTopPost.Models
{
    public class PagesTopModel
    {
        public static bool isInitialized { get; set; }

        public int PageCurrent { get; set; }
        public int PageCount { get; set; }
        public int PageItemCount { get; set; }
        public int MaxPageVisible { get; set; }
        public List<Message> DisplayMessages { get; set; }
        public List<int> Pages { get; set; }

        public PagesTopModel()
        {
            MaxPageVisible = 7;
            PageItemCount = 15;
            DisplayMessages = new List<Message>();
            Pages = new List<int>();
        }
    }
}
