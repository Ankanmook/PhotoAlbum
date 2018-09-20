using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoAlbum.Models
{
    public class PageResponse<T> where T : class
    {
        public List<T> Results { get; set; }
        public int RecordCount { get; set; }
        public int PageCount { get; set; }

        public int Page { get; set; }
        public int PageSize { get; set; }

        public static PageResponse<T> ReturnPageResponse(List<T> completeResultSet, int Page, int PageSize)
        {
            PageResponse<T> pageResponse = new PageResponse<T>();
            pageResponse.RecordCount = completeResultSet.Count;
            pageResponse.Page = Page;
            pageResponse.PageSize = PageSize;
            pageResponse.Results = completeResultSet.Skip(Page * PageSize).Take(PageSize).ToList();

            pageResponse.PageCount = (int)Math.Ceiling((double)pageResponse.RecordCount / PageSize);
            return pageResponse;
        }
    }
}
