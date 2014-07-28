using System.Threading.Tasks;
using System.Web.Mvc;
using Ninject;
using Zubrs.Models;
using Zubrs.Mvc.Infrastructure;

namespace Zubrs.Mvc.Controllers
{
    public class ManagementController : Controller
    {
        [Inject]
        public MenuManager MenuManager { get; set; }

        public async Task<ActionResult> Index()
        {
            await MenuManager.InitAsync(RouteName.Management);

            var data = new[]
            {
                new Manager { Title = "Председатель", Name = "Угляница Надежда Александровна" },
                new Manager { Title = "Заместитель председателя", Name = "Лукашевич Анна Евгеньевна", ImageUrl = "//zubrs.brest.by/images/stories/zubrs/handling/lukashevich_a.jpg" },
                new Manager { Title = "Директор", Name = "Лукашевич Игорь Бернардович", ImageUrl = "//zubrs.brest.by/images/stories/zubrs/handling/lukashevich_i.jpg" },
                new Manager { Title = "Член правления", Name = "Белисов Николай Макарович" },
                new Manager { Title = "Член правления", Name = "Рачевский Станислав Григорьевич" },
                new Manager { Title = "Член правления", Name = "Новик Василий Иванович" }
            };

            return View(data);
        }
    }
}