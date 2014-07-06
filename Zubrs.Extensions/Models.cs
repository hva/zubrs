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
    }
}
