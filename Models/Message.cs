namespace TheTopPost.Models
{
    public class Message
    {
        public long Id { get; set; }
        public string Ip { get; set; }
        public string Text { get; set; }
        public string NameImage { get; set; }
        public string Date { get; set; }
        public long Raiting { get; set; }
    }
}
