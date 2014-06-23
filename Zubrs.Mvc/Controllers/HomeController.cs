using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using Ninject;
using Zubrs.Data;
using Zubrs.Models;
using Zubrs.Mvc.Infrastructure;
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
            });
        }

        private async Task<Game[][]> LoadGamesAsync()
        {
            var res = await Repository.Games
                .Include(x => x.Competition)
                .Include(x => x.Home)
                .Include(x => x.Away)
                .ToArrayAsync();
            return res.Chunk(4);
        }
    }
}