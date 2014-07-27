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
        public Season[] Seasons { get; set; }

        public async Task InitAsync()
        {
            Games = await LoadGamesAsync();

            var news = await Repository.Articles
                .Where(x => !string.IsNullOrEmpty(x.ImageUrl))
                .Where(x => x.Type == ArticleType.General || x.Type == ArticleType.Kids)
                .ToArrayAsync();
            GeneralNews = news.Where(x => x.Type == ArticleType.General).ToArray();
            KidNews = news.Where(x => x.Type == ArticleType.Kids).ToArray();

            Video = await Repository.Videos.FirstAsync();

            Seasons = await LoadSeasonsAsync();
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

        private async Task<Season[]> LoadSeasonsAsync()
        {
            var seasons = await Repository.Seasons
                .Include(x => x.Competition)
                .Where(x => x.ShowOnSplash)
                .ToArrayAsync();

            // TODO: try to run in single query
            foreach (var s in seasons)
            {
                await Repository.LoadRanksAsync(s);
            }

            return seasons;
        }
    }
}