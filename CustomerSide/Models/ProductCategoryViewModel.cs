using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using E_commerce.Shared.Paging;

namespace CustomerSide.Models
{
    public class ProductCategoryViewModel
    {
        public CategoriesViewModel Category { get; set; }

        public List <ProductsViewModel> Products { get; set; }
    }
}
