using System;
using System.Collections.Generic;
using System.Linq;
using Ninject;
using Zubrs.Data;
using Zubrs.Models;
using Zubrs.Mvc.Infrastructure;

namespace Zubrs.Mvc.ViewModels
{
    public class NavViewModel
    {
        private Lazy<MenuItem[]> menuLazy;

        public NavViewModel()
        {
            menuLazy = new Lazy<MenuItem[]>(() => CreateMenu().ToArray());
        }

        [Inject]
        public IDataRepository Repository { get; set; }

        public MenuItem[] Menu { get { return menuLazy.Value; } }

        private IEnumerable<MenuItem> CreateMenu()
        {
            yield return new MenuItem { Title = "Новости", RouteName = RouteName.News };
            yield return new MenuItem
            {
                Title = "Команды",
                RouteName = RouteName.Teams,
                SubItems = CreateTeamsMenu(),
            };
            yield return new MenuItem
            {
                Title = "Соревнования",
                RouteName = RouteName.Competitions,
                SubItems = CreateCompetitionsMenu(),
            };

            yield return new MenuItem { Title = "Руководство", RouteName = RouteName.Management };
            yield return new MenuItem { Title = "История", RouteName = RouteName.History };
            yield return new MenuItem { Title = "Фото", RouteName = RouteName.Photo };
            yield return new MenuItem { Title = "Видео", RouteName = RouteName.Video };
        }

        private IEnumerable<MenuItem> CreateTeamsMenu()
        {
            var competitions = Repository.GetTeams();
            return competitions.Where(x => x.ShowInMenu).Select(x =>
                new MenuItem
                {
                    Title = x.Title,
                    RouteName = RouteName.Team,
                    RouteParams = new { id = x.Id }
                }
            );
        }

        private IEnumerable<MenuItem> CreateCompetitionsMenu()
        {
            var competitions = Repository.GetCompetitions();
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