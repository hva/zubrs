using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using Ninject;
using Zubrs.Data;
using Zubrs.Models;
using Zubrs.Mvc.Infrastructure;

namespace Zubrs.Mvc.Controllers
{
    public class NewsController : Controller
    {
        [Inject]
        public IDataRepository Repository { get; set; }

        [Inject]
        public MenuManager MenuManager { get; set; }

        public async Task<ActionResult> List(int? page)
        {
            await MenuManager.InitAsync(RouteName.News);

            var model = new PaginatedList<Article>(page ?? 0, 5);
            var source = Repository.Articles
                .Where(x => x.Type != ArticleType.History)
                .OrderByDescending(x => x.Created);
            await model.SetSourceAsync(source);
            return View(model);
        }

        public async Task<ActionResult> Detail(int id)
        {
            await MenuManager.InitAsync(RouteName.News);
            var model = await Repository.Articles.FirstAsync(x => x.Id == id);
            return View(model);
        }

    }
}