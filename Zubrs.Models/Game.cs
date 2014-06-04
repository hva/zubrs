using System;

namespace Zubrs.Models
{
    public class Game
    {
        public int Id { get; set; }
        public int CompetitionId { get; set; }
        public int? HomeId { get; set; }
        public int? AwayId { get; set; }
        public int HomeScore { get; set; }
        public int AwayScore { get; set; }
        public DateTime Date { get; set; }

        public Competition Competition { get; set; }
        public Team Home { get; set; }
        public Team Away { get; set; }
    }
}