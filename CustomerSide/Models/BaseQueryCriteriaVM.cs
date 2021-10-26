using E_commerce.Shared.Enum;

namespace CustomerSide.Models
{
    public class BaseQueryCriteriaVM
    {
        public string Search { get; set; }
        public SortOrderEnum SortOrder { get; set; }
        public string SortColumn { get; set; }
        public int Limit { get; set; } = 10;
        public int Page { get; set; } = 1;
    }
}