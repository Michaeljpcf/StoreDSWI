using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StoreDSWI.Web.ViewModels
{
    public class BaseListingViewModels
    {

    }

    public class Pager
    {
        public Pager (int totalItems, int? page, int pageSize = 10)
        {
            if (pageSize == 0) pageSize = 10;

            var totalPages = (int)Math.Ceiling((decimal)totalItems / (decimal)pageSize);
            var currentPage = page != null ? (int)page : 1;
            var starPage = currentPage - 5;
            var endPage = currentPage + 4;

            if (starPage <= 0)
            {
                endPage -= (starPage - 1);
                starPage = 1;
            }
            if (endPage > totalPages)
            {
                endPage = totalPages;
                if (endPage > 10)
                {
                    starPage = endPage - 9;
                }
            }

            TotalItems = totalItems;
            CurrentPage = currentPage;
            PageSize = pageSize;
            TotalPages = totalPages;
            StartPage = starPage;
            EndPage = endPage;
        }

        public int TotalItems { get; private set; }
        public int CurrentPage { get; private set; }
        public int PageSize { get; private set; }
        public int TotalPages { get; private set; }
        public int StartPage { get; private set; }
        public int EndPage { get; private set; }
    }
}