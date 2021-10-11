using E_commerce.Data.Models;
using E_commerce.Data.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_commerce.Data.Services
{
    public class CategoriesService
    {
        private AppDBContext _context;
        public CategoriesService(AppDBContext context)
        {
            _context = context;
        }
        public void AddProduct(CategoryVM category)
        {
            var _category = new Categories()
            {
                Name = category.Name,
            };
            _context.Categories.Add(_category);
            _context.SaveChanges();
        }
        public List<Categories> GetAllCategory() => _context.Categories.ToList();
        public Categories GetCategoryByID(int categoryID) => _context.Categories.FirstOrDefault(n => n.Id == categoryID);
        public Categories UpdateProductByID(int categoryID, CategoryVM category)
        {
            var _category = _context.Categories.FirstOrDefault(n => n.Id == categoryID);
            if (_category != null)
            {
                _category.Name = category.Name;
                _context.SaveChanges();
            }
            return _category;
        }
        public Categories DeleteProductByID(int categoryID)
        {
            var _category = _context.Categories.FirstOrDefault(n => n.Id == categoryID);
            if (_category != null)
            {
                _context.Categories.Remove(_category);
                _context.SaveChanges();
            }
            return _category;
        }
    }
}
