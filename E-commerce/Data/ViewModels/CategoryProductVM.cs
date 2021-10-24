using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_commerce.Data.ViewModels
{
    public class CategoryProductVM
    {
        public string Name { get; set; }
        public List<ProductVM> Products { get; set; }
    }
}
