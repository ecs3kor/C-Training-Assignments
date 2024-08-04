using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bosch.eCommerce.Models
{
    public class Pagination<T> :List<T>
    {
        public int TotalPages { get; set; }
        public int PageIndex { get; set; }

        public Pagination(List<T> items, int count, int pageIndex, int pageSize)
        {
            PageIndex = pageIndex;
            TotalPages = (int)Math.Ceiling(count/(double)pageSize);
            this.AddRange(items);
        }

        public bool HasPreviousPage => PageIndex > 1;
        public bool HasNextPage => PageIndex < TotalPages;

        public static Pagination<T> Create(List<T> items, int pageIndex, int pageSize)
        {
            var count = items.Count;
            var itemss= items.Skip((pageIndex -1)*pageSize).Take(pageSize).ToList();
            return new Pagination<T>(itemss, count, pageIndex, pageSize);
        }
    }
}
