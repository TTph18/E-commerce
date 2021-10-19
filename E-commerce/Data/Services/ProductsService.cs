using E_commerce.Data.ViewModels;
using E_commerce.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using E_commerce.Data.Paging;
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
        public void AddProductWithCategory(ProductVM product)
        {
            var _product = new Products()
            {
                Name = product.Name,
                Rate = product.Rate,
                Description = product.Description,
                Price = product.Price,
                PictureUrl = product.PictureUrl,
                CategoryID = product.CategoryID
            };
            _context.Products.Add(_product);
            _context.SaveChanges();
        }
        public List<Products> GetAllProduct(string sortBy, string filterString, int? pageNumber) 
        { 
            var allProducts = _context.Products.ToList();
            var allCategories = _context.Categories.ToList();

            //Sorting
            if (!string.IsNullOrEmpty(sortBy))
            {
                switch(sortBy)
                {
                    case "name_desc":
                        allProducts = allProducts.OrderByDescending(n => n.Name).ToList();
                        break;
                    case "name_asc":
                        allProducts = allProducts.OrderBy(n => n.Name).ToList();
                        break;
                    default:
                        break;
                }
            }

            //Filtering
            if (!string.IsNullOrEmpty(filterString))
            {
                var filterCategory = allCategories.Where(n => n.Name.Contains(filterString, 
                    StringComparison.CurrentCultureIgnoreCase)).
                    FirstOrDefault();
                allProducts = allProducts.Where(n => n.CategoryID.Equals(filterCategory.Id)).ToList();
            }

            //Paging
            int pageSize = 4;
            allProducts = PaginatedList<Products>.Create(allProducts.AsQueryable(), pageNumber ?? 1, pageSize);

            return allProducts;
        }
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
                _product.CategoryID = product.CategoryID;
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
