using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Zubrs.Data;
using Zubrs.Models;
using Zubrs.Mvc.Infrastructure;

namespace Zubrs.Mvc.Controllers
{
    public class NavController : Controller
    {
        public PartialViewResult TopBar()
        {
            var menu = CreateMenu(true);
            return PartialView(menu);
        }

        public PartialViewResult BottomBar()
        {
            var menu = CreateMenu(false);
            return PartialView(menu);
        }

        private static IEnumerable<MenuItem> CreateMenu(bool loadSubItems)
        {
            List<MenuItem> menu = new List<MenuItem>(7)
            {
                new MenuItem {Title = "Новости", RouteName = RouteName.News},
            };

            var teams = new MenuItem { Title = "Команды", RouteName = RouteName.Teams };
            if (loadSubItems)
            {
                teams.SubItems = CreateTeamsMenu();
            }
            menu.Add(teams);

            var competitions = new MenuItem { Title = "Соревнования", RouteName = RouteName.Competitions };
            if (loadSubItems)
            {
                competitions.SubItems = CreateCompetitionsMenu();
            }
            menu.Add(competitions);

            menu.Add( new MenuItem { Title = "Руководство", RouteName = RouteName.Management });
            menu.Add( new MenuItem { Title = "История", RouteName = RouteName.History });
            menu.Add( new MenuItem { Title = "Фото", RouteName = RouteName.Photo });
            menu.Add( new MenuItem { Title = "Видео", RouteName = RouteName.Video });

            return menu;
        }

        private static IEnumerable<MenuItem> CreateTeamsMenu()
        {
            IDataRepository repository = new DataRepository();
            var competitions = repository.GetTeams();
            return competitions.Where(x => x.ShowInMenu).Select(x =>
                new MenuItem
                {
                    Title = x.Title,
                    RouteName = RouteName.Team,
                    RouteParams = new { id = x.Id }
                }
            );
        }

        private static IEnumerable<MenuItem> CreateCompetitionsMenu()
        {
            IDataRepository repository = new DataRepository();
            var competitions = repository.GetCompetitions();
            return competitions.Select(x =>
                new MenuItem
                {
                    Title = x.Title,
                    RouteName = RouteName.Competition,
                    RouteParams = new { id = x.Id }
                }
            );
        }
    }
}