using System.Collections.Generic;
using Zubrs.Models;

namespace Zubrs.Mvc.ViewModels
{
    public class SeasonTableViewModel
    {
        public Season Season { get; set; }
        public IEnumerable<Rank> Ranks { get; set; }
    }
}