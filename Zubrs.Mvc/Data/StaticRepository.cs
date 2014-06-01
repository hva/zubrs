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

        public Task<IEnumerable<Team>> GetTeamsAsync()
        {
            return Task.FromResult(LoadTeams());
        }

        private static IEnumerable<Competition> LoadCompetitions()
        {
            yield return new Competition { Id = 1, Title = "Чемпионат РБ", TitleShort = "ЧРБ" };
            yield return new Competition { Id = 2, Title = "Кубок РБ", TitleShort = "КРБ" };
        }

        private IEnumerable<Team> LoadTeams()
        {
            yield return new Team { Id = 1, Title = "Брестские Зубры", TitleShort = "зубры", ShowInMenu = true };
            yield return new Team { Id = 2, Title = "Брестские Зубры-2", TitleShort = "зубры 2", ShowInMenu = true };
            yield return new Team { Id = 2, Title = "Минск" };
            yield return new Team { Id = 2, Title = "Сахарный Шторм" };
            yield return new Team { Id = 2, Title = "Логишинские Волки" };
        }
    }
}