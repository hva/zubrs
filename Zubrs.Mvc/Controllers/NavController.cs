using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using Zubrs.Data;
using Zubrs.Models;
using Zubrs.Mvc.Infrastructure;

namespace Zubrs.Mvc.Controllers
{
    public class NavController : AsyncController
    {
        public async Task<PartialViewResult> TopBar()
        {
            var menu = await CreateMenu(true);
            return PartialView(menu);
        }

        public async Task<PartialViewResult> BottomBar()
        {
            var menu = await CreateMenu(false);
            return PartialView(menu);
        }

        private async static Task<IEnumerable<MenuItem>> CreateMenu(bool loadSubItems)
        {
            List<MenuItem> menu = new List<MenuItem>(7)
            {
                new MenuItem {Title = "Новости", RouteName = RouteName.News},
            };

            var teams = new MenuItem { Title = "Команды", RouteName = RouteName.Teams };
            if (loadSubItems)
            {
                teams.SubItems = await CreateTeamsMenu();
            }
            menu.Add(teams);

            var competitions = new MenuItem { Title = "Соревнования", RouteName = RouteName.Competitions };
            if (loadSubItems)
            {
                competitions.SubItems = await CreateCompetitionsMenu();
            }
            menu.Add(competitions);

            menu.Add( new MenuItem { Title = "Руководство", RouteName = RouteName.Management });
            menu.Add( new MenuItem { Title = "История", RouteName = RouteName.History });
            menu.Add( new MenuItem { Title = "Фото", RouteName = RouteName.Photo });
            menu.Add( new MenuItem { Title = "Видео", RouteName = RouteName.Video });

            return menu;
        }

        private async static Task<IEnumerable<MenuItem>> CreateTeamsMenu()
        {
            IDataRepository repository = new DataRepository();
            var competitions = await repository.GetTeamsAsync();
            return competitions.Where(x => x.ShowInMenu).Select(x =>
                new MenuItem
                {
                    Title = x.Title,
                    RouteName = RouteName.Team,
                    RouteParams = new { id = x.Id }
                }
            );
        }

        private async static Task<IEnumerable<MenuItem>> CreateCompetitionsMenu()
        {
            IDataRepository repository = new DataRepository();
            var competitions = await repository.GetCompetitionsAsync();
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