using System;
using System.ComponentModel.DataAnnotations;

namespace Zubrs.Models
{
    public class Game
    {
        public int Id { get; set; }
        public int SeasonId { get; set; }
        public int HomeId { get; set; }
        public int AwayId { get; set; }
        public int HomeScore { get; set; }
        public int AwayScore { get; set; }
        public GamePlace Place { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd MMM yyyy, HH:mm}")]
        public DateTime Date { get; set; }

        public virtual Season Season { get; set; }
        public virtual Team Home { get; set; }
        public virtual Team Away { get; set; }

        public string Score
        {
            get { return string.Format("{0} : {1}", HomeScore, AwayScore); }
        }
    }
}