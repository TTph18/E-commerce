using System.Collections.Generic;

namespace CustomerSide.Models
{
    public class PagingResponseVM<TViewModel> : BaseQueryCriteriaVM
    {
        public int CurrentPage { get; set; }

        public int TotalItems { get; set; }

        public int TotalPages { get; set; }

        public IEnumerable<TViewModel> Items { get; set; }

        public bool HasPreviousPage
        {
            get
            {
                return (Page > 1);
            }
        }

        public bool HasNextPage
        {
            get
            {
                return (Page < TotalPages);
            }
        }
    }
}
