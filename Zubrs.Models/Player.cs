namespace Zubrs.Models
{
    public class Player
    {
        public int Id { get; set; }
        public int TeamId { get; set; }
        public string ImageUrl { get; set; }
        public string Name { get; set; }
        public int Number { get; set; }
        public string Position { get; set; }

        public virtual Team Team { get; set; }
    }
}
