using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using Ninject;
using Zubrs.Data;
using Zubrs.Extensions;
using Zubrs.Models;

namespace Zubrs.Mvc.ViewModels
{
    public class HomeViewModel
    {
        [Inject]
        public IDataRepository Repository { get; set; }

        public Game[][] Games { get; set; }
        public Article[] GeneralNews { get; set; }
        public Article[] KidNews { get; set; }
        public Video Video { get; set; }
        public SeasonTableViewModel[] SeasonTables { get; set; }

        public async Task InitAsync()
        {
            Games = await LoadGamesAsync();

            var news = await Repository.Articles.Where(x => !string.IsNullOrEmpty(x.ImageUrl)).ToArrayAsync();
            GeneralNews = news.Where(x => x.Type == ArticleType.General).ToArray();
            KidNews = news.Where(x => x.Type == ArticleType.Kids).ToArray();

            Video = await Repository.Videos.FirstAsync();

            SeasonTables = await LoadSeasonTablesAsync();
        }

        private async Task<Game[][]> LoadGamesAsync()
        {
            var res = await Repository.Games
                .Include(x => x.Season.Competition)
                .Include(x => x.Home)
                .Include(x => x.Away)
                .Where(x => x.Home.ShowInMenu || x.Away.ShowInMenu)
                .ToArrayAsync();
            return res.Chunk(4);
        }

        private async Task<SeasonTableViewModel[]> LoadSeasonTablesAsync()
        {
            var res = await Repository.Ranks
                .Include(x => x.Team)
                .Include(x => x.Season.Competition)
                .Where(x => x.Season.ShowOnSplash)
                .OrderByDescending(z => z.Percentage)
                .ThenByDescending(z => z.GamesPlayed)
                .ToArrayAsync();

            // grouping on client side
            // because Include() not working
            return res
                .GroupBy(x => x.Season)
                .Select(x => new SeasonTableViewModel
                {
                    Season = x.Key,
                    Ranks = x
                })
                .ToArray();
        }
    }
}