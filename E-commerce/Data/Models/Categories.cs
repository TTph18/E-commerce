using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_commerce.Data.Models
{
    public class Categories
    {
        public int Id { get; set; }
        public string Name { get; set; }
        //
        public List<Products> Product { get; set; }
    }
}
