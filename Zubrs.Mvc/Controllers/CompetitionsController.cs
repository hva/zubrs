using System.Threading.Tasks;
using System.Web.Mvc;
using Ninject;
using Zubrs.Mvc.Infrastructure;
using Zubrs.Mvc.ViewModels;

namespace Zubrs.Mvc.Controllers
{
    public class CompetitionsController : Controller
    {
        [Inject]
        public CompetitionViewModel ViewModel { get; set; }

        [Inject]
        public MenuManager MenuManager { get; set; }

        public async Task<ActionResult> Index(int? id)
        {
            await MenuManager.InitAsync(RouteName.Competitions);
            await ViewModel.InitAsync(id);
            return View(ViewModel);
        }
    }
}