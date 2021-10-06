using System.Collections.Generic;

namespace TheTopPost.Models
{
    public class PagesTopModel
    {
        public int PageCurrent { get; set; }
        public int PageCount { get; set; }
        public int PageItemCount { get; set; }
        public int MaxPageVisible { get; set; }
        public List<Message> DisplayMessages { get; set; }
        public List<int> Pages { get; set; }

        public PagesTopModel()
        {
            MaxPageVisible = 5;
            PageItemCount = 6;
            DisplayMessages = new List<Message>();
        }
    }
}
