using System.Data.Entity;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using Ninject;
using Zubrs.Data;
using Zubrs.Extensions;
using Zubrs.Models;
using Zubrs.Mvc.ViewModels;

namespace Zubrs.Mvc.Controllers
{
    public class HomeController : Controller
    {
        [Inject]
        public IDataRepository Repository { get; set; }

        public async Task<ActionResult> Index()
        {
            var news = await Repository.Articles.Where(x => !string.IsNullOrEmpty(x.ImageUrl)).ToArrayAsync();
            return View(new HomeViewModel
            {
                Games = await LoadGamesAsync(),
                GeneralNews = news.Where(x => x.Type == ArticleType.General).ToArray(),
                KidNews = news.Where(x => x.Type == ArticleType.Kids).ToArray(),
                Video = await Repository.Videos.FirstAsync(),
                SeasonTables = await LoadSeasonTablesAsync(),
            });
        }

        private async Task<Game[][]> LoadGamesAsync()
        {
            var res = await Repository.Games
                .Include(x => x.Season.Competition)
                .Include(x => x.Home)
                .Include(x => x.Away)
                .ToArrayAsync();
            return res.Chunk(4);
        }

        private async Task<SeasonTableViewModel[]> LoadSeasonTablesAsync()
        {
            Repository.SetLog(x => Debug.Write(x));
            var res = await Repository.Ranks
                .Include(x => x.Season.Competition)
                .GroupBy(x => x.Season)
                .Select(x => new SeasonTableViewModel
                {
                    Season = x.Key,
                    Ranks = x
                })
                .ToArrayAsync();
            return res;
        }
    }
}