using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using Ninject;
using Zubrs.Data;
using Zubrs.Models;

namespace Zubrs.Mvc.ViewModels
{
    public class TeamViewModel
    {
        [Inject]
        public IDataRepository Repository { get; set; }

        public Team[] Teams { get; set; }
        public Team Team { get; set; }

        public async Task InitAsync(int? id)
        {
            Teams = await Repository.Teams.Where(x => x.ShowInMenu).ToArrayAsync();
            Team = (id.HasValue)
                ? await Repository.Teams.FirstAsync(x => x.Id == id)
                : Teams.First();
        }
    }
}