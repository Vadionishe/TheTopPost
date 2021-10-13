using System.ComponentModel.DataAnnotations;

namespace TheTopPost.Models
{
    public class Message
    {
        [Key]
        public long Id { get; set; }
        public string Ip { get; set; }
        public string Text { get; set; }
        public string NameImage { get; set; }
        public byte[] BytesImage { get; set; }
        public string ImageMimeType { get; set; }
        public string Date { get; set; }
        public long Raiting { get; set; }
        public string Code { get; set; }
    }
}
