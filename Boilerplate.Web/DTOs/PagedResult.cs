using System;
using System.Collections.Generic;

namespace Boilerplate.Web.DTOs
{
    public class PagedResult<T>
    {
        public IEnumerable<T> Items { get; set; } = Array.Empty<T>();
        public long TotalCount { get; set; }
        public int PageCount { get; set; }
        public int PageSize { get; set; }
    }
}
