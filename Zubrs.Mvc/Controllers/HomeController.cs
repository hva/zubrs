using System.Web.Mvc;
using Ninject;
using Zubrs.Data;
using Zubrs.Mvc.ViewModels;

namespace Zubrs.Mvc.Controllers
{
    public class HomeController : Controller
    {
        [Inject]
        public IDataRepository Repository { get; set; }

        public ActionResult Index()
        {
            var model = new HomeViewModel();
            return View(model);
        }
    }
}