﻿using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using Ninject;
using Zubrs.Data;
using Zubrs.Models;

namespace Zubrs.Mvc.Infrastructure
{
    public class MenuManager
    {
        [Inject]
        public IDataRepository Repository { get; set; }

        public MenuItem[] Items { get; private set; }

        public async Task InitAsync(string currentRouteName)
        {
            var teams = await CreateTeamsMenuAsync();
            var competitions = await CreateCompetitionsMenuAsync();
            var history = await CreateHistoryMenuAsync();

            Items = new[]
            {
                new MenuItem
                {
                    Title = "Новости",
                    RouteName = RouteName.News,
                    IsActive = currentRouteName == RouteName.News,
                },
                new MenuItem
                {
                    Title = "Команды",
                    RouteName = RouteName.Teams,
                    SubItems = teams,
                    IsActive = currentRouteName == RouteName.Teams,
                },
                new MenuItem
                {
                    Title = "Соревнования",
                    RouteName = RouteName.Competitions,
                    SubItems = competitions,
                    IsActive = currentRouteName == RouteName.Competitions,
                },
                new MenuItem
                {
                    Title = "Руководство",
                    RouteName = RouteName.Management,
                    IsActive = currentRouteName == RouteName.Management,
                },
                new MenuItem
                {
                    Title = "История",
                    RouteName = RouteName.History,
                    SubItems = history,
                    IsActive = currentRouteName == RouteName.History,
                }
                //new MenuItem { Title = "Фото", RouteName = RouteName.Photo },
                //new MenuItem { Title = "Видео", RouteName = RouteName.Video }
            };
        }

        private async Task<MenuItem[]> CreateTeamsMenuAsync()
        {
            var res = await Repository.Teams
                .Where(x => x.ShowInMenu)
                .OrderBy(x => x.Sortorder)
                .ToArrayAsync();
            return res.Select(x => new MenuItem
                {
                    Title = x.Title,
                    RouteName = RouteName.Team,
                    RouteParams = new { id = x.Id }
                }).ToArray();
        }

        private async Task<MenuItem[]> CreateCompetitionsMenuAsync()
        {
            var res = await Repository.Competitions.ToArrayAsync();
            return res.Select(x => new MenuItem
                {
                    Title = x.Title,
                    RouteName = RouteName.Competition,
                    RouteParams = new { id = x.Id }
                }).ToArray();
        }

        private async Task<MenuItem[]> CreateHistoryMenuAsync()
        {
            var res = await Repository.Articles.Where(x => x.Type == ArticleType.History).ToArrayAsync();
            return res.Select(x => new MenuItem
                {
                    Title = x.MenuTitle,
                    RouteName = RouteName.HistoryItem,
                    RouteParams = new { id = x.Id }
                }).ToArray();
        }
    }
}