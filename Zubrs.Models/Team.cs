using System.Collections.Generic;

namespace Zubrs.Models
{
    public class Team
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string TitleShort { get; set; }
        public bool ShowInMenu { get; set; }
        public int Sortorder { get; set; }

        public virtual ICollection<Player> Players { get; set; }
    }
}