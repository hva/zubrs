using System.Linq;
using Ninject;
using Zubrs.Data;
using Zubrs.Models;

namespace Zubrs.Mvc.Infrastructure
{
    public class MenuManager
    {
        private MenuItem[] items;

        [Inject]
        public IDataRepository Repository { get; set; }

        public string CurrentRouteName { get; set; }

        public MenuItem[] Items
        {
            get { return items ?? (items = CreateMenu()); }
        }

        private MenuItem[] CreateMenu()
        {
            return new[]
            {
                new MenuItem
                {
                    Title = "Новости",
                    RouteName = RouteName.News,
                    IsActive = CurrentRouteName == RouteName.News,
                },
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
            var res = Repository.Teams.Where(x => x.ShowInMenu).Select(x =>
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
            var res = Repository.Competitions.Select(x =>
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