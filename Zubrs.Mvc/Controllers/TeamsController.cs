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

        public TeamsController(MenuManager menuManager)
        {
            menuManager.CurrentRouteName = RouteName.Teams;
        }

        public async Task<ActionResult> Index(int? id)
        {
            await ViewModel.InitAsync(id);
            return View(ViewModel);
        }
    }
}