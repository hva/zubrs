using System.Data.Entity;
using System.Threading.Tasks;
using System.Web.Mvc;
using Ninject;
using Zubrs.Data;
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

        public async Task<ActionResult> List()
        {
            var model = await Repository.Articles.ToArrayAsync();
            return View(model);
        }

        public async Task<ActionResult> Detail(int id)
        {
            var model = await Repository.Articles.FirstAsync(x => x.Id == id);
            return View(model);
        }

    }
}