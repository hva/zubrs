using System;
using System.Data.Entity;
using Zubrs.Models;

namespace Zubrs.Data
{
    public class DataInitializer : CreateDatabaseIfNotExists<ZubrsContext>
    {
        private Team zubrs, zubrs2, minsk, sugar, wolves;
        private Competition champ, cup;
        private Season champ_2013, cup_2013;

        protected override void Seed(ZubrsContext db)
        {
            AddTeams(db);
            AddCompetitions(db);
            AddSeasons(db);
            AddGames(db);

            // we need to insert items in database
            // before ranks calculating
            db.SaveChanges();

            db.RefreshSeasonRanks(champ_2013.Id);
            db.RefreshSeasonRanks(cup_2013.Id);

            AddPlayers(db);
            AddArticles(db);
            AddVideos(db);

            db.SaveChanges();
            base.Seed(db);
        }

        private void AddTeams(ZubrsContext db)
        {
            db.Teams.AddRange(new[]
            {
                zubrs = new Team {Title = "Брестские Зубры", TitleShort = "зубры", ShowInMenu = true, Sortorder = 0},
                zubrs2 =
                    new Team {Title = "Брестские Зубры-2", TitleShort = "зубры 2", ShowInMenu = true, Sortorder = 1},
                minsk = new Team {Title = "Минск"},
                sugar = new Team {Title = "Сахарный Шторм"},
                wolves = new Team {Title = "Логишинские Волки"}
            });
        }

        private void AddCompetitions(ZubrsContext db)
        {
            db.Competitions.AddRange(new[]
            {
                champ = new Competition { Title = "Чемпионат РБ", TitleShort = "ЧРБ" },
                cup = new Competition { Title = "Кубок РБ", TitleShort = "КРБ" }
            });
        }

        private void AddSeasons(ZubrsContext db)
        {
            db.Seasons.AddRange(new[]
            {
                champ_2013 = new Season { Competition = champ, Year = 2013 },
                cup_2013 = new Season { Competition = cup, Year = 2013 }
            });
        }

        private void AddGames(ZubrsContext db)
        {
            db.Games.AddRange(new[]
            {
                new Game { Season = champ_2013, Date = new DateTime(2013, 10, 25, 12, 0, 0), Home = zubrs, Away = zubrs2, HomeScore = 12, AwayScore = 4, Place = GamePlace.Brest },
                new Game { Season = champ_2013, Date = new DateTime(2013, 10, 25, 15, 0, 0), Home = wolves, Away = minsk, HomeScore = 13, AwayScore = 10, Place = GamePlace.Logishin },
                new Game { Season = champ_2013, Date = new DateTime(2013, 10, 26, 12, 0, 0), Home = zubrs2, Away = wolves, HomeScore = 13, AwayScore = 3, Place = GamePlace.Brest },
                new Game { Season = champ_2013, Date = new DateTime(2013, 10, 25, 15, 0, 0), Home = zubrs, Away = minsk, HomeScore = 14, AwayScore = 4, Place = GamePlace.Brest },
                new Game { Season = cup_2013, Date = new DateTime(2013, 10, 17, 12, 0, 0), Home = minsk, Away = sugar, HomeScore = 0, AwayScore = 20, Place = GamePlace.Minsk },
                new Game { Season = cup_2013, Date = new DateTime(2013, 10, 17, 15, 0, 0), Home = zubrs, Away = wolves, HomeScore = 12, AwayScore = 11, Place = GamePlace.Brest },
                new Game { Season = cup_2013, Date = new DateTime(2013, 10, 18, 12, 0, 0), Home = minsk, Away = zubrs, HomeScore = 5, AwayScore = 7, Place = GamePlace.Minsk },
                new Game { Season = cup_2013, Date = new DateTime(2013, 10, 18, 15, 0, 0), Home = sugar, Away = wolves, HomeScore = 9, AwayScore = 2, Place = GamePlace.Skidel },
                new Game { Season = cup_2013, Date = new DateTime(2013, 10, 19, 12, 0, 0), Home = wolves, Away = minsk, HomeScore = 0, AwayScore = 9, Place = GamePlace.Logishin }
            });
        }

        private void AddPlayers(ZubrsContext db)
        {
            db.Players.AddRange(new[]
            {
                new Player { Team = zubrs, Name = "Кочурко Алексей", Number = 19, Position = "C,3B", ImageUrl = "//zubrs.brest.by/site/players/photos/ka4.jpg" },
                new Player { Team = zubrs, Name = "Поплавский Андрей", Number = 7, Position = "P,OF", ImageUrl = "//zubrs.brest.by/site/players/photos/pop.jpg" },
                new Player { Team = zubrs, Name = "Огулик Андрей", Number = 28, Position = "2B", ImageUrl = "//zubrs.brest.by/site/players/photos/ogu.jpg" },
                new Player { Team = zubrs, Name = "Ветров Вадим", Number = 33, Position = "P,3B,OF", ImageUrl = "//zubrs.brest.by/site/players/photos/vet.jpg" },
                new Player { Team = zubrs, Name = "Назаренко Антон", Number = 15, Position = "OF", ImageUrl = "//zubrs.brest.by/site/players/photos/naz.jpg" },
                new Player { Team = zubrs, Name = "Карват Дмитрий", Number = 17, Position = "1B,OF", ImageUrl = "//zubrs.brest.by/site/players/photos/kar.jpg" },

                new Player { Team = zubrs2, Name = "Александров Алексей", Number = 1, Position = "3B,OF", ImageUrl = "//zubrs.brest.by/site/players/photos/ale.jpg" },
                new Player { Team = zubrs2, Name = "Лось Андрей", Number = 5, Position = "P,1B,OF", ImageUrl = "//zubrs.brest.by/site/players/photos/los.jpg" },
                new Player { Team = zubrs2, Name = "Сокол Сергей", Number = 7, Position = "2B,SS,OF", ImageUrl = "//zubrs.brest.by/site/players/photos/sok.jpg" },
                new Player { Team = zubrs2, Name = "Кашевский Илья", Number = 11, Position = "OF,P", ImageUrl = "//zubrs.brest.by/site/players/photos/18.jpg" },
                new Player { Team = zubrs2, Name = "Лукашевич Алексей", Number = 77, Position = "P,SS,OF", ImageUrl = "//zubrs.brest.by/site/players/photos/lyk.jpg" }
            });
        }

        private static void AddArticles(ZubrsContext db)
        {
            db.Articles.AddRange(new[]
            {
                new Article {
                    Title = "\"Кубок Бреста - 2013\"",
                    ImageUrl = "//zubrs.brest.by/components/com_datsogallery/img_originals/pic001.JPG",
                    PreText = "3-6 октября 2013 года в г. Бресте состоится III Международный турнир по бейсболу «Кубок Бреста- 2013», в котором примут участие десять команд из России, Литвы и Беларуси. Организаторами турнира выступили – Брестский горисполком и бейсбольно-софтбольный клуб «Брестские зубры».",
                    Text = "За главный трофей турнира – Кубок Бреста – будут бороться игроки 2001 года рождения и младше. В прошлом, 2012 году, победителем II Международного  турнира стала команда «Вильнюс».  «Брестские зубры» завоевали серебряные награды.\n\nУчастники турнира:\n\nГруппа А:  1. «Вильнюс» (г. Вильнюс, Литва); 2. «Сахарный шторм» (г.Скидель, Беларусь); 3. «Акулы» (Россия); 4. \"СДЮСШОР \"Балашиха\" (г. Балашиха, Россия); 5. «Брестские зубры-2» (г. Брест, Беларусь)\n\nГруппа Б: 1.  «Брестские зубры» (г. Брест, Беларусь); 2. «Литуаника» (г. Каунас, Литва); 3.  «Северные звезды, СДЮСШОР – 42» (г. Москва, Россия); 4. «Москвич» (г. Москва, Россия);   5. «Минск» (г. Минск, Беларусь).\n\nТоржественное открытие турнира 4 октября в 16-30.\n\nЖдем всех на бейсбольных стадионах г. Бреста!",
                },
                new Article {
                    Title = "\"Брестские зубры\" успешно завершили сезон 2013г. Поздравляем!",
                    ImageUrl = "//zubrs.brest.by/components/com_datsogallery/img_pictures/pic016.JPG",
                    PreText = "Финальным аккордом сезона игр 2013 года стала победа \"Брестских зубров\" (ювенилы U-12) в международном турнире \"Кубок Вильнюса 2013\", который прошел 27-29 декабря 2013г. в г. Вильнюсе (Литва). В финальной игре брестчане переиграли команду \"Москвич\" (Россия) со счетом 9-8. Всего в группе ювенилов приняло участие 10 команд из Литвы, Эстонии, России и Беларуси.",
                    Text = "Команда кадетов U-15 стала бронзовым призером данного турнира. В игре за третье место \"Брестские зубры\" переиграли команду \"Вильнюс\" со счетом 2-1. В группе кадетов участвовало 12 команд из России, Литвы и Беларуси.\n\nНакануне выезда на турнир прошло торжественное чествование команд клуба \"Брестские зубры\" и подведение итогов сезона игр 2013г. Клуб награжден Почетной грамотой Управления спорта и туризма Брестского облисполкома за высокие спортивные достижения. Грамоту вручил начальник УСиТ БОИК Николайчук Э.В. председателю правления клуба Углянице Н.А.\n\nВсе команды клуба и лучшие игроки были награждены дипломами, медалями, кубками, призами и сладкими подарками от Деда Мороза, Снегурочки и спонсоров клуба - Отеля \"Эрмитаж\" и Брестского филиала РУП \"Белтелеком\".\n\nФото см. здесь: [http://photo.qip.ru/users/andrejka2006/200694712/212602781/](http://photo.qip.ru/users/andrejka2006/200694712/212602781/)\n\nЧитаем о нас: [http://www.bk-brest.by/ru/216/sport/7330/](http://www.bk-brest.by/ru/216/sport/7330/)",
                },
                new Article {
                    Title = "Кубок Европы 2014 пройдет в г. Бресте",
                    ImageUrl = "//zubrs.brest.by/components/com_datsogallery/img_pictures/pic010.JPG",
                    PreText = "В минувшие выходные, 23-24 ноября 2014г., во Франкфурте техническая комиссия и исполнительный комитет C.E.B. утвердили список стран, которые примут у себя квалификационные Кубки Европы по бейсболу.",
                    Text = "С 16 по 21 июня 2014г. четыре отборочных турнира  состоятся  в:  \n**Антверпене (Бельгия). Афинах (Греция),  Бресте (Беларусь) и Стокгольме (Швеция)**.\n\nИ вновь большой бейсбол приедет в Беларусь! Поздравляем всех любителей бейсбола с этой новостью!\n\nНапомним, что Брест уже трижды (2006, 2008, 2010гг.) принимал Кубки Европы (квалификация)  и  в 2011 г. – чемпионат Европы среди ювенилов. Следите за новостями на нашем сайте!",
                },
                new Article {
                    Title = "Брестские зубры - победители Первенства Беларуси среди юниоров",
                    ImageUrl = "//zubrs.brest.by/components/com_datsogallery/img_originals/6_023.JPG",
                    PreText = "25 - 27 октября 2013 г. в г.п.  Логишин (Брестская область) состоялось Первенство Беларуси по бейсболу среди юниоров (юноши 1995 г.р. и младше). \"Брестские зубры\" были представлены двумя командами. Первая команда - Брестские зубры во всех играх одержала победы и в итоге стала победителем первенства. Команда \"Минск\" заняла второе место, уступив только основной команде Бреста, на третье место с одной победой и двумя поражениями вышла команда  \"Брестские зубры-2\".",
                    Text = "**Лучшими игроками Первенства признаны:**\n\nMVP самый полезный игрок первенства – **Демчук Илья**, («Брестские зубры», г.Брест);\n\nЛучший питчер – **Козловский Кирилл**, («Брестские зубры», г.Брест);\n\nЛучший бьющий – **Кукса Глеб**, («Минск», г.Минск);\n\nЛучший защитник – **Юшкевич Николай**, («Логишинские волки», г.п. Логишин).\n\n**Итоговая таблица:**\n\n1. Брестские зубры (г.Брест, Брестская обл.).\n\n2. Минск (г.Минск).\n\n3. Брестские зубры - 2 (г.Брест, Брестская обл.).\n\n4. Логишинские волки (г.п. Логишин, Брестская обл.).\n\n**Поздравляем победителя и призеров с успешным результатом!**\n\nРезультаты смотрите в разделе [соревнования](competitions.php).",
                    Type = ArticleType.Kids,
                },
                new Article {
                    Title = "Брестские зубры - обладатели Кубка Республики Беларусь по бейсболу 2013 года",
                    ImageUrl = "//zubrs.brest.by/components/com_datsogallery/img_pictures/pic019.JPG",
                    PreText = "\"Брестские зубры\" - девятикратные обладатели Кубка Республики Беларусь по бейсболу 2013 года.",
                    Text = "Вот и завершился игровой сезон для основных клубных команд Республики Беларусь по бейсболу.  С 17 по 20 октября в г. Скиделе проходил Кубок Беларуси. Представители четырех клубов разыгрывали звание обладателя Кубка. Многие игры прошли в упорной борьбе, до конца матчей не было ясно кто победит. Погода в октябре тоже преподнесла свои сюрпризы, нарушив планы команд. Микротравмы ряда игроков команды \"Брестские зубры\" - победителя Кубка Беларуси 2013г., также осложнили выполнение поставленной цели. Брестчане в упорной борьбе одолели команду Логишинские волки со счетом 12:11, Минск 7:5 и Сахарный шторм 5:4. В финальной игре с командой Сахарный шторм, Брестские зубры одержали победу с результатом 10:4, став обладателями Кубка Беларуси 2013 года.\n\n**Итоговая таблица Кубка Республики Беларусь 2013г.**\n\n1. Брестские зубры (г.Брест).\n2. Сахарный шторм (г.Скидель).\n3. Минск (г.Минск).\n4. Логишинские волки (г.п. Логишин, Брестская область).",
                },
                new Article {
                    Title = "Брестские зубры победители первенства Беларуси среди кадетов",
                    ImageUrl = "//zubrs.brest.by/components/com_datsogallery/img_originals/6_024.JPG",
                    PreText = "11 - 13 октября 2013 г. в г. Бресте (Брестская область) прошло Первенство Беларуси по бейсболу среди кадетов (юноши 1998 г.р. и младше). \"Брестские зубры\" были представлены двумя командами. Первая команда - Брестские зубры во всех играх одержала победы и в итоге стала победителем первенства. Команда \"Сахарный шторм\" в упорной борьбе заняла второе место, уступив только основной команде Бреста, на третье место с двумя победами и двумя поражениями вышла команда  из г.п. Логишин «Логишинские волки».",
                    Text = "**Лучшими игроками Первенства признаны:**\n\n* MVP самый полезный игрок первенства - **Коробко Кирилл**, («Брестские зубры», г.Брест);\n* Лучший питчер - **Ильин Владислав**, («Брестские зубры», г.Брест);\n* Лучший бьющий – **Кургун Евгений**, («Сахарный шторм», г. Скидель);\n* Лучший защитник – **Лось Артем**, («Логишинские волки», г.п. Логишин).",
                    Type = ArticleType.Kids,
                },
                new Article {
                    Title = "Брестские зубры - серебряные и бронзовые призеры первенства среди мальчиков",
                    ImageUrl = "//zubrs.brest.by/components/com_datsogallery/img_originals/6_026.JPG",
                    PreText = "11 - 13 октября 2013 г. в г. Бресте (Брестская область) завершилось Первенство Беларуси по бейсболу среди мальчиков 2001 г.р. и младше. \"Брестские зубры\" в очередной раз были представлены двумя командами. Первая команда Брестские зубры в упорной борьбе заняла 2 место, уступив команде Сахарный шторм со счетом 1:5. Вторая наша команда \"Брестские зубры-2\"  заняла третье место, оставив позади соперников из \"Минска\".",
                    Text = "**Лучшими игроками Первенства признаны:**\n\n* MVP самый полезный игрок первенства – **Кукла Роман**, («Сахарный шторм», г. Скидель);\n* Лучший питчер – **Ярошенко Кирилл**, («Брестские зубры», г.Брест);\n* Лучший бьющий – **Сергиенко Евгений**, («Брестские зубры», г.Брест);\n* Лучший защитник – **Новик Николай**, («Сахарный шторм», г. Скидель).",
                    Type = ArticleType.Kids,
                }
            });
        }

        private static void AddVideos(ZubrsContext db)
        {
            db.Videos.AddRange(new[]
            {
                new Video { Title = "brest zubrs", VideoUrl = "//www.youtube.com/embed/eoItalLp9yo" },
                new Video { Title = "Alexandr Lukashevich", VideoUrl = "//www.youtube.com/embed/ajLyQodaePM" },
                new Video { Title = "Алекс Лукашевич", VideoUrl = "//www.youtube.com/embed/RCQixaysF8s" }
            });
        }
    }
}