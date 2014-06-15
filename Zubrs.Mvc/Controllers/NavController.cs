using System.Linq;
using System.Web.Mvc;
using Zubrs.Data;
using Zubrs.Models;
using Zubrs.Mvc.Infrastructure;

namespace Zubrs.Mvc.Controllers
{
    public class NavController : Controller
    {
        private IDataRepository repository;
        private MenuItem[] menu;

        public NavController(IDataRepository repository)
        {
            this.repository = repository;
            menu = CreateMenu();
        }

        public PartialViewResult TopBar()
        {
            return PartialView(menu);
        }

        public PartialViewResult BottomBar()
        {
            return PartialView(menu);
        }

        private MenuItem[] CreateMenu()
        {
            return new[]
            {
                new MenuItem { Title = "Новости", RouteName = RouteName.News },
                new MenuItem
                {
                    Title = "Команды",
                    RouteName = RouteName.Teams,
                    SubItems = CreateTeamsMenu(),
                },
                new MenuItem
                {
                    Title = "Соревнования",
                    RouteName = RouteName.Competitions,
                    SubItems = CreateCompetitionsMenu(),
                },
                new MenuItem { Title = "Руководство", RouteName = RouteName.Management },
                new MenuItem { Title = "История", RouteName = RouteName.History },
                new MenuItem { Title = "Фото", RouteName = RouteName.Photo },
                new MenuItem { Title = "Видео", RouteName = RouteName.Video }
            };
        }

        private MenuItem[] CreateTeamsMenu()
        {
            var res = repository.Teams.Where(x => x.ShowInMenu).Select(x =>
                new MenuItem
                {
                    Title = x.Title,
                    RouteName = RouteName.Team,
                    RouteParams = new { id = x.Id }
                }
            );
            return res.ToArray();
        }

        private MenuItem[] CreateCompetitionsMenu()
        {
            var res = repository.Competitions.Select(x =>
                new MenuItem
                {
                    Title = x.Title,
                    RouteName = RouteName.Competition,
                    RouteParams = new { id = x.Id }
                }
            );
            return res.ToArray();
        }

    }
}