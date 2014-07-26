using System.Collections.Generic;

namespace Zubrs.Models
{
    public class Season
    {
        public int Id { get; set; }
        public int Year { get; set; }
        public int CompetitionId { get; set; }
        public bool ShowOnSplash { get; set; }

        public Competition Competition { get; set; }
        public ICollection<Game> Games { get; set; }
    }
}
