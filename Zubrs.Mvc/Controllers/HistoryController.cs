using System.Threading.Tasks;
using System.Web.Mvc;
using Ninject;
using Zubrs.Mvc.Infrastructure;
using Zubrs.Mvc.ViewModels;

namespace Zubrs.Mvc.Controllers
{
    public class HistoryController : Controller
    {
        [Inject]
        public HistoryViewModel ViewModel { get; set; }

        [Inject]
        public MenuManager MenuManager { get; set; }

        public async Task<ActionResult> Index(int? id)
        {
            MenuManager.CurrentRouteName = RouteName.History;
            await ViewModel.InitAsync(id);
            return View(ViewModel);
        }
    }
}