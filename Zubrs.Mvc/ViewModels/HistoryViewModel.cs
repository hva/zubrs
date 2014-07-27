using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Ninject;
using Zubrs.Data;
using Zubrs.Models;

namespace Zubrs.Mvc.ViewModels
{
    public class HistoryViewModel
    {
        [Inject]
        public IDataRepository Repository { get; set; }

        public Article[] Items { get; set; }
        public Article Item { get; set; }

        public async Task InitAsync(int? id)
        {
            Items = await Repository.Articles.Where(x => x.Type == ArticleType.History).ToArrayAsync();
            Item = Items.FirstOrDefault(x => !id.HasValue || x.Id == id);
            if (Item == null)
            {
                throw new HttpException(404, "Page not found");
            }
        }
    }
}