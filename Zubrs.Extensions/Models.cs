using System.Collections.Generic;
using Zubrs.Models;

namespace Zubrs.Extensions
{
    public static class Models
    {
        public static void IncRank(this IDictionary<int, Rank> table, int teamId, bool won)
        {
            Rank rank;
            if (!table.TryGetValue(teamId, out rank))
            {
                rank = new Rank { TeamId = teamId };
                table.Add(teamId, rank);
            }
            rank.GamesPlayed++;
            if (won)
            {
                rank.GamesWon++;
            }
        }

        public static string DisplayName(this GamePlace place)
        {
            switch (place)
            {
                case GamePlace.Brest: return "Брест";
                case GamePlace.Minsk: return "Минск";
                case GamePlace.Skidel: return "Скидель";
                case GamePlace.Logishin: return "Логишин";
            }
            return null;
        }
    }
}
