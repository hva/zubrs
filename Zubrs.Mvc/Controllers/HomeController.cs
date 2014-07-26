using System.Threading.Tasks;
using System.Web.Mvc;
using Ninject;
using Zubrs.Mvc.ViewModels;

namespace Zubrs.Mvc.Controllers
{
    public class HomeController : Controller
    {
        [Inject]
        public HomeViewModel ViewModel { get; set; }

        public async Task<ActionResult> Index()
        {
            await ViewModel.InitAsync();
            return View(ViewModel);
        }
    }
}