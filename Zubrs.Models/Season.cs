namespace Zubrs.Models
{
    public class Season
    {
        public int Id { get; set; }
        public int Year { get; set; }
        public int CompetitionId { get; set; }

        public virtual Competition Competition { get; set; }
    }
}
