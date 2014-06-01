using System;
using System.Collections.Generic;
using System.Web.Mvc;
using Zubrs.Mvc.Infrastrucrure;
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
            yield return new MenuItem { Title = "Новости", RouteName = RouteName.News };
            yield return new MenuItem { Title = "Команды", RouteName = RouteName.Teams };
            yield return new MenuItem { Title = "Соревнования", RouteName = RouteName.Competitions, SubItems = CreateCompetitionsMenu() };
        }

        private static IEnumerable<MenuItem> CreateCompetitionsMenu()
        {
            yield return new MenuItem { Title = "Чемпионат РБ", RouteName = RouteName.Competition, RouteParams = new { id = 1 } };
            yield return new MenuItem { Title = "Кубок РБ", RouteName = RouteName.Competition, RouteParams = new { id = 2 } };
        }
    }
}