using System.Threading.Tasks;
using System.Web.Mvc;
using Ninject;
using Zubrs.Mvc.Infrastructure;
using Zubrs.Mvc.ViewModels;

namespace Zubrs.Mvc.Controllers
{
    public class TeamsController : Controller
    {
        [Inject]
        public TeamViewModel ViewModel { get; set; }

        [Inject]
        public MenuManager MenuManager { get; set; }

        public async Task<ActionResult> Index(int? id)
        {
            await MenuManager.InitAsync(RouteName.Teams);
            await ViewModel.InitAsync(id);
            return View(ViewModel);
        }
    }
}