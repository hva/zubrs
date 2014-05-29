using System;
using System.Collections.Generic;
using System.Web.Mvc;
using Zubrs.Mvc.Models;

namespace Zubrs.Mvc.Controllers
{
    public class NavController : Controller
    {
        private readonly Lazy<IEnumerable<MenuItem>> menuLazy = new Lazy<IEnumerable<MenuItem>>(CreateMenu);

        public PartialViewResult TopBar()
        {
            return PartialView(menuLazy.Value);
        }

        public PartialViewResult BottomBar()
        {
            return PartialView(menuLazy.Value);
        }

        private static IEnumerable<MenuItem> CreateMenu()
        {
            yield return new MenuItem { Title = "Новости", Controller = "news" };
            yield return new MenuItem { Title = "Команды", Controller = "teams" };
            yield return new MenuItem { Title = "Соревнования", Controller = "competitions" };
        }
    }
}