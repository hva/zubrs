using System.Collections.Generic;
using System.Threading.Tasks;
using Zubrs.Mvc.Models;

namespace Zubrs.Mvc.Data
{
    public class StaticRepository : IRepository
    {
        public Task<IEnumerable<Competition>> GetCompetitionsAsync()
        {
            return Task.FromResult(LoadCompetitions());
        }

        private static IEnumerable<Competition> LoadCompetitions()
        {
            yield return new Competition { Id = 1, Title = "Чемпионат РБ", ShortTitle = "ЧРБ" };
            yield return new Competition { Id = 2, Title = "Кубок РБ", ShortTitle = "КРБ" };
        }
    }
}