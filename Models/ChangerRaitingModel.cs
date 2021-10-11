namespace TheTopPost.Models
{
    public enum TypeChange
    {
        Up,
        Down
    }

    public class ChangerRaitingModel
    {
        public int Page { get; set; }
        public long Id { get; set; }
        public TypeChange TypeChange { get; set; }
    }
}
