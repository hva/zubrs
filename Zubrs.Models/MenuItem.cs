using System.Collections.Generic;
using System.Linq;

namespace Zubrs.Models
{
    public class MenuItem
    {
        public string Title { get; set; }
        public string RouteName { get; set; }
        public object RouteParams { get; set; }
        public bool IsActive { get; set; }
        public IEnumerable<MenuItem> SubItems { get; set; }

        public bool HasSubItems
        {
            get { return SubItems != null && SubItems.Any(); }
        }
    }
}