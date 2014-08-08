using System.Threading.Tasks;
using System.Web.Mvc;
using Ninject;
using Zubrs.Mvc.Infrastructure;

namespace Zubrs.Mvc.Controllers
{
    public class UserController : Controller
    {
        [Inject]
        public MenuManager MenuManager { get; set; }

        public async Task<ActionResult> Login()
        {
            await MenuManager.InitAsync(null);
            return View();
        }
    }
}