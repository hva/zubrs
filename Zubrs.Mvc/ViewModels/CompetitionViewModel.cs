using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using Ninject;
using Zubrs.Data;
using Zubrs.Models;

namespace Zubrs.Mvc.ViewModels
{
    public class CompetitionViewModel
    {
        [Inject]
        public IDataRepository Repository { get; set; }

        public Competition[] Competitions { get; set; }
        public Competition Competition { get; set; }

        public async Task InitAsync(int? id)
        {
            Competitions = await Repository.Competitions.ToArrayAsync();
            Competition = id.HasValue
                ? Competitions.First(x => x.Id == id)
                : Competitions[0];
        }
    }
}