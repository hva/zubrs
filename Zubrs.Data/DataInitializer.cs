using System.Data.Entity;
using Zubrs.Models;

namespace Zubrs.Data
{
    public class DataInitializer : DropCreateDatabaseIfModelChanges<ZubrsContext>
    {
        protected override void Seed(ZubrsContext db)
        {
            db.Teams.AddRange(new[]
            {
                new Team { Title = "Брестские Зубры", TitleShort = "зубры", ShowInMenu = true},
                new Team { Title = "Брестские Зубры-2", TitleShort = "зубры 2", ShowInMenu = true },
                new Team { Title = "Минск" },
                new Team { Title = "Сахарный Шторм" },
                new Team { Title = "Логишинские Волки" },
            });

            db.Competitions.AddRange(new[]
            {
                new Competition { Title = "Чемпионат РБ", TitleShort = "ЧРБ" },
                new Competition { Title = "Кубок РБ", TitleShort = "КРБ" },
            });

            base.Seed(db);
        }
    }
}