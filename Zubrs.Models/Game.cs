using System;

namespace Zubrs.Models
{
    public class Game
    {
        public int Id { get; set; }
        public int CompetitionId { get; set; }
        public int HomeId { get; set; }
        public int AwayId { get; set; }
        public int HomeScore { get; set; }
        public int AwayScore { get; set; }
        public DateTime Date { get; set; }

        public virtual Competition Competition { get; set; }
        public virtual Team Home { get; set; }
        public virtual Team Away { get; set; }
    }
}