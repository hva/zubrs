using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
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
            Teams = await Repository.Teams
                .Where(x => x.ShowInMenu)
                .OrderBy(x => x.Sortorder)
                .ToArrayAsync();

            Team = Teams.FirstOrDefault(x => !id.HasValue || x.Id == id);
            if (Team == null)
            {
                throw new HttpException(404, "Page not found");
            }
            await Repository.LoadPlayersAsync(Team);
        }
    }
}