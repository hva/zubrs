using System.Collections.Generic;
using Zubrs.Models;

namespace Zubrs.Mvc.ViewModels
{
    public class HomeViewModel
    {
        public IEnumerable<Game> Games { get; set; }
    }
}