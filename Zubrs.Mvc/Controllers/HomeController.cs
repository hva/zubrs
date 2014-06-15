using System;
using System.Collections;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using Ninject;
using Zubrs.Data;
using Zubrs.Models;
using Zubrs.Mvc.Infrastructure;
using Zubrs.Mvc.ViewModels;

namespace Zubrs.Mvc.Controllers
{
    public class HomeController : Controller
    {
        [Inject]
        public IDataRepository Repository { get; set; }

        public async Task<ActionResult> Index()
        {
            return View(new HomeViewModel
            {
                Games = await LoadGamesAsync()
            });
        }

        private async Task<Game[]> LoadGamesAsync()
        {
            var res = await Repository.Games.ToArrayAsync();

            var asd = res.Chunk(2).ToArray();

            return res;
        }
    }
}