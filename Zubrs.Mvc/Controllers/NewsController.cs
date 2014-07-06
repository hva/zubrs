using System.Web.Mvc;
using Zubrs.Mvc.Infrastructure;

namespace Zubrs.Mvc.Controllers
{
    public class NewsController : Controller
    {
        public NewsController(MenuManager menu)
        {
            menu.CurrentRouteName = RouteName.News;
        }

        public ActionResult Index()
        {
            return View();
        }
    }
}