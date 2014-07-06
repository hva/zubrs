using System.Web.Mvc;
using Ninject;
using Zubrs.Mvc.Infrastructure;

namespace Zubrs.Mvc.Controllers
{
    public class NavController : Controller
    {
        [Inject]
        public MenuManager MenuManager { get; set; }

        public PartialViewResult TopBar()
        {
            return PartialView(MenuManager.Items);
        }

        public PartialViewResult BottomBar()
        {
            return PartialView(MenuManager.Items);
        }
    }
}