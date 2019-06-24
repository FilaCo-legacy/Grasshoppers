using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Grasshoppers.Models
{
    public class PaginationViewModel<T> : List <T>, IPaginationViewModel
    {
        public int PageIndex { get; private set; }
        
        public int TotalPages { get; private set; }

        public bool HasPreviousPage => PageIndex > 1;

        public bool HasNextPage => PageIndex < TotalPages;

        public PaginationViewModel(IEnumerable <T> items, int count, int pageIndex, int pageSize)
        {
            AddRange(items);
            
            PageIndex = pageIndex;
            TotalPages = (int) Math.Ceiling(count / (double) pageSize);
        }

        public static async Task<PaginationViewModel<T>> CreateAsync(IQueryable<T> source, int pageIndex, int pageSize)
        {
            var count = await source.CountAsync();
            var items = await source.Skip((pageIndex - 1) * pageSize).Take(pageSize).ToListAsync();
            
            return new PaginationViewModel<T>(items, count, pageIndex, pageSize);
        }
    }
}