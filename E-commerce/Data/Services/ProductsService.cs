using E_commerce.Data.ViewModels;
using E_commerce.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_commerce.Data.Services
{
    public class ProductsService
    {
        private AppDBContext _context;
        public ProductsService(AppDBContext context)
        {
            _context = context;
        }
        public void AddProduct(ProductVM product)
        {
            var _product = new Products()
            {
                Name = product.Name,
                Description = product.Description,
                Price = product.Price,
                PictureUrl = product.PictureUrl
            };
            _context.Products.Add(_product);
            _context.SaveChanges();
        }
    }
}
