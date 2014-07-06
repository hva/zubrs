using System.ComponentModel.DataAnnotations;

namespace Zubrs.Models
{
    public class Rank
    {
        public int Id { get; set; }
        public int TeamId { get; set; }
        public int SeasonId { get; set; }
        public int GamesPlayed { get; set; }
        public int GamesWon { get; set; }

        public virtual Team Team { get; set; }
        public virtual Season Season { get; set; }

        [DisplayFormat(DataFormatString = "{0:F3}")]
        public double Coeff
        {
            get
            {
                return GamesWon / (double)GamesPlayed;
            }
        }
    }
}
