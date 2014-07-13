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

        public NewsController(MenuManager menu)
        {
            menu.CurrentRouteName = RouteName.News;
        }

        public async Task<ActionResult> List(int? page)
        {
            var model = new PaginatedList<Article>(page ?? 0, 5);
            await model.SetSourceAsync(Repository.Articles.OrderByDescending(x => x.Created));
            return View(model);
        }

        public async Task<ActionResult> Detail(int id)
        {
            var model = await Repository.Articles.FirstAsync(x => x.Id == id);
            return View(model);
        }

    }
}