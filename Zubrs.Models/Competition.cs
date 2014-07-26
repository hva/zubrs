using System.Collections.Generic;

namespace Zubrs.Models
{
    public class Competition
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string TitleShort { get; set; }

        public ICollection<Season> Seasons { get; set; }
    }
}