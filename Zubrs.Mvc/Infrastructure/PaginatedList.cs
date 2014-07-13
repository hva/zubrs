using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace Zubrs.Mvc.Infrastructure
{
    public class PaginatedList<T> : List<T>
    {
        public int PageIndex { get; private set; }
        public int PageSize { get; private set; }
        public int TotalCount { get; private set; }
        public int TotalPages { get; private set; }

        public PaginatedList(int pageIndex, int pageSize)
        {
            PageIndex = pageIndex;
            PageSize = pageSize;
        }

        public async Task SetSourceAsync(IQueryable<T> source)
        {
            TotalCount = await source.CountAsync();
            TotalPages = (int)Math.Ceiling(TotalCount / (double)PageSize);
            var range = await source.Skip(PageIndex*PageSize).Take(PageSize).ToArrayAsync();
            AddRange(range);
        }

        public bool HasPreviousPage
        {
            get
            {
                return (PageIndex > 0);
            }
        }

        public bool HasNextPage
        {
            get
            {
                return (PageIndex + 1 < TotalPages);
            }
        }
    }
}