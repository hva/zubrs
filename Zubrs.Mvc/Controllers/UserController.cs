using System.Threading.Tasks;
using System.Web.Mvc;
using Ninject;
using Zubrs.Mvc.Infrastructure;
using Zubrs.Mvc.ViewModels;

namespace Zubrs.Mvc.Controllers
{
    [Authorize]
    public class UserController : Controller
    {
        [Inject]
        public MenuManager MenuManager { get; set; }

        [AllowAnonymous]
        public async Task<ActionResult> Login()
        {
            await MenuManager.InitAsync(null);
            return View(new LoginViewModel());
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Login(LoginViewModel vm)
        {
            await MenuManager.InitAsync(null);
            return View(vm);
        }
    }
}