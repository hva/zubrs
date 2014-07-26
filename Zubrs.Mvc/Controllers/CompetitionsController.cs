using System.Web.Mvc;
using Zubrs.Mvc.Infrastructure;

namespace Zubrs.Mvc.Controllers
{
    public class CompetitionsController : Controller
    {
        public CompetitionsController(MenuManager menuManager)
        {
            menuManager.CurrentRouteName = RouteName.Competitions;
        }

        public ActionResult Index(int? id)
        {
            return View();
        }
    }
}