using System.Web.Mvc;
using Ninject;
using Zubrs.Mvc.ViewModels;

namespace Zubrs.Mvc.Controllers
{
    public class NavController : Controller
    {
        [Inject]
        public NavViewModel ViewModel { get; set; }

        public PartialViewResult TopBar()
        {
            return PartialView(ViewModel);
        }

        public PartialViewResult BottomBar()
        {
            return PartialView(ViewModel);
        }

    }
}