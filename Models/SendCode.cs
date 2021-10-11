using System.ComponentModel.DataAnnotations;

namespace TheTopPost.Models
{
    public class SendCode
    {
        [Key]
        public long Id { get; set; }
        public string Code { get; set; }
        public bool IsUsed { get; set; }
    }
}
