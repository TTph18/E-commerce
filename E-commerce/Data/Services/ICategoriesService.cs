using E_commerce.Data.Models;
using E_commerce.Data.ViewModels;
using E_commerce.Shared.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_commerce.Data.Services
{
    public interface ICategoriesService
    {
        void AddCategory(CategoryVM category);
        List<Categories> GetAllCategory();
        CategoryVM GetCategoryByID(int categoryID);
        CategoryProductVM GetCategoryData(int categoryId);
        Categories UpdateCategoryByID(int categoryID, CategoryVM category);
        Categories DeleteCategoryByID(int categoryID);


    }
}
