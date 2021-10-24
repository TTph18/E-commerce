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
        public void AddCategory(CategoryVM category)
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
        public CategoryProductVM GetCategoryData(int categoryId)
        {
            var _categoryData = _context.Categories.Where(n => n.Id == categoryId)
                .Select(n => new CategoryProductVM()
                {
                    Name = n.Name,
                    Products = n.Product.Select(n => new ProductVM()
                    {
                        Id = n.Id,
                        Name = n.Name,
                        Price = n.Price,
                        PictureUrl = n.PictureUrl,
                        Rate = n.Rate
                    }).ToList()
                }).FirstOrDefault();

            return _categoryData;
        }
        public Categories UpdateCategoryByID(int categoryID, CategoryVM category)
        {
            var _category = _context.Categories.FirstOrDefault(n => n.Id == categoryID);
            if (_category != null)
            {
                _category.Name = category.Name;
                _context.SaveChanges();
            }
            return _category;
        }
        public Categories DeleteCategoryByID(int categoryID)
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
