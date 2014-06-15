using System.Collections.Generic;
using System.Data.Entity;
using System.Threading.Tasks;
using Ninject;
using Zubrs.Data;
using Zubrs.Models;

namespace Zubrs.Mvc.ViewModels
{
    public class HomeViewModel
    {
        [Inject]
        public IDataRepository Repository { get; set; }

        public IEnumerable<Game> Games { get; private set; }

        public async Task LoadAsync()
        {
            Games = await Repository.Games.ToArrayAsync();
        }
    }
}