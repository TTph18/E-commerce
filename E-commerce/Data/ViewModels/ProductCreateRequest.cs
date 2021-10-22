using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_commerce.Data.ViewModels
{
    public class ProductCreateRequest
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public float Price { get; set; }
        public int? CategoryID { get; set; }
        public IFormFile ImageFile { get; set; }
    }
}
