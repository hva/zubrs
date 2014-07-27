using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Ninject;
using Zubrs.Data;
using Zubrs.Models;

namespace Zubrs.Mvc.ViewModels
{
    public class CompetitionViewModel
    {
        [Inject]
        public IDataRepository Repository { get; set; }

        public Competition[] Competitions { get; set; }
        public Competition Competition { get; set; }
        public Season Season { get; set; }

        public async Task InitAsync(int? id)
        {
            Competitions = await Repository.Competitions
                .Include(x => x.Seasons)
                .ToArrayAsync();

            Competition = Competitions.FirstOrDefault(x => !id.HasValue || x.Id == id);
            if (Competition == null)
            {
                throw new HttpException(404, "Page not found");
            }

            Season = Competition.Seasons.FirstOrDefault();
            if (Season == null)
            {
                throw new HttpException(404, "Page not found");
            }

            await Repository.LoadGamesAsync(Season);
            await Repository.LoadRanksAsync(Season);
        }
    }
}