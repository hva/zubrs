using System.Collections.Generic;
using System.Linq;

namespace Zubrs.Extensions
{
    public static class Collections
    {
        //public static IEnumerable<IEnumerable<T>> Chunk<T>(this IEnumerable<T> list, int chunkSize)
        //{
        //    int i = 0;
        //    var chunks = from name in list
        //                 group name by i++ / chunkSize into part
        //                 select part.AsEnumerable();
        //    return chunks;
        //}

        public static T[][] Chunk<T>(this IEnumerable<T> list, int chunkSize)
        {
            int i = 0;
            var chunks = from name in list
                         group name by i++ / chunkSize into part
                         select part.ToArray();
            return chunks.ToArray();
        }
    }
}
