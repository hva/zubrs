using System.Threading.Tasks;
using System.Web.Mvc;
using Ninject;
using Zubrs.Mvc.Infrastructure;
using Zubrs.Mvc.ViewModels;

namespace Zubrs.Mvc.Controllers
{
    public class UserController : Controller
    {
        [Inject]
        public MenuManager MenuManager { get; set; }

        public async Task<ActionResult> Login()
        {
            await MenuManager.InitAsync(null);
            return View(new LoginViewModel());
        }
    }
}