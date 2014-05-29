using System.Web.Mvc;

namespace Zubrs.Mvc.Controllers
{
    public class NavController : Controller
    {
        public PartialViewResult TopBar()
        {
            return PartialView();
        }
    }
}