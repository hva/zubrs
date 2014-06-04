using System;
using System.Data.Entity;
using Zubrs.Models;

namespace Zubrs.Data
{
    public class DataInitializer : DropCreateDatabaseIfModelChanges<ZubrsContext>
    {
        protected override void Seed(ZubrsContext db)
        {
            Team zubrs, zubrs2, minsk, sugar, wolves;
            db.Teams.AddRange(new[]
            {
                zubrs = new Team { Title = "Брестские Зубры", TitleShort = "зубры", ShowInMenu = true},
                zubrs2 = new Team { Title = "Брестские Зубры-2", TitleShort = "зубры 2", ShowInMenu = true },
                minsk = new Team { Title = "Минск" },
                sugar = new Team { Title = "Сахарный Шторм" },
                wolves = new Team { Title = "Логишинские Волки" }
            });

            Competition bl, bc;
            db.Competitions.AddRange(new[]
            {
                bl = new Competition { Title = "Чемпионат РБ", TitleShort = "ЧРБ" },
                bc = new Competition { Title = "Кубок РБ", TitleShort = "КРБ" }
            });

            db.Games.AddRange(new[]
            {
                new Game { Competition = bl, Date = new DateTime(2013, 10, 25, 12, 0, 0), Home = zubrs, Away = zubrs2, HomeScore = 12, AwayScore = 4, },
                new Game { Competition = bl, Date = new DateTime(2013, 10, 25, 15, 0, 0), Home = wolves, Away = minsk, HomeScore = 13, AwayScore = 10, },
                new Game { Competition = bl, Date = new DateTime(2013, 10, 26, 12, 0, 0), Home = zubrs2, Away = wolves, HomeScore = 13, AwayScore = 3, },
                new Game { Competition = bl, Date = new DateTime(2013, 10, 25, 15, 0, 0), Home = zubrs, Away = minsk, HomeScore = 14, AwayScore = 4, },
                new Game { Competition = bc, Date = new DateTime(2013, 10, 17, 12, 0, 0), Home = minsk, Away = sugar, HomeScore = 0, AwayScore = 20, },
                new Game { Competition = bc, Date = new DateTime(2013, 10, 17, 15, 0, 0), Home = zubrs, Away = wolves, HomeScore = 12, AwayScore = 11, },
                new Game { Competition = bc, Date = new DateTime(2013, 10, 18, 12, 0, 0), Home = minsk, Away = zubrs, HomeScore = 5, AwayScore = 7, },
                new Game { Competition = bc, Date = new DateTime(2013, 10, 18, 15, 0, 0), Home = sugar, Away = wolves, HomeScore = 9, AwayScore = 2, },
                new Game { Competition = bc, Date = new DateTime(2013, 10, 19, 12, 0, 0), Home = wolves, Away = minsk, HomeScore = 0, AwayScore = 9, }
            });

            base.Seed(db);
        }
    }
}