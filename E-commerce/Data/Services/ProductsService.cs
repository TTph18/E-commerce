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
        public List<Products> GetAllProduct() => _context.Products.ToList();
        public Products GetProductByID(int productID) => _context.Products.FirstOrDefault(n => n.Id == productID);
        public Products UpdateProductByID(int productID, ProductVM product)
        {
            var _product = _context.Products.FirstOrDefault(n => n.Id == productID);
            if(_product != null)
            {
                _product.Name = product.Name;
                _product.Description = product.Description;
                _product.Price = product.Price;
                _product.PictureUrl = product.PictureUrl;
                _context.SaveChanges();
            }
            return _product;
        }
        public Products DeleteProductByID(int productID)
        {
            var _product = _context.Products.FirstOrDefault(n => n.Id == productID);
            if (_product != null)
            {
                _context.Products.Remove(_product);
                _context.SaveChanges();
            }
            return _product;
        }
    }
}
