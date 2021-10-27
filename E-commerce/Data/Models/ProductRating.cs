using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_commerce.Data.Models
{
    public class ProductRating
    {
        public int Id { get; set; }
        public int ProductID { get; set; }
        public int Rating { get; set; }
    }
}
