using System.Data.Entity;
using Zubrs.Models;

namespace Zubrs.Data
{
    public class DataInitializer : DropCreateDatabaseAlways<ZubrsContext>
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

            base.Seed(db);
        }
    }
}