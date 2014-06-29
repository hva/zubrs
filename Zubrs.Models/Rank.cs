namespace Zubrs.Models
{
    public class Rank
    {
        public int Id { get; set; }
        public int Place { get; set; }
        public int Points { get; set; }
        public int TeamId { get; set; }
        public int SeasonId { get; set; }

        public virtual Team Team { get; set; }
        public virtual Season Season { get; set; }
    }
}
