using E_commerce.Data.Services;
using E_commerce.Data.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_commerce.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        public CategoriesService _categoriesService;
        public CategoriesController(CategoriesService categoriesService)
        {
            _categoriesService = categoriesService;
        }
        [HttpGet("get-all-categories")]
        public IActionResult GetAllCategories()
        {
            var allcategories = _categoriesService.GetAllCategory();
            return Ok(allcategories);
        }

        [HttpGet("get-category-by-id/{id}")]
        public IActionResult GetCategoryByID(int id)
        {
            var category = _categoriesService.GetCategoryByID(id);
            return Ok(category);
        }

        [HttpPost("add-category")]
        public IActionResult AddCategory([FromBody] CategoryVM category)
        {
            _categoriesService.AddCategory(category);
            return Ok();
        }

        [HttpPut("update-category-by-id/{id}")]
        public IActionResult UpdateCategoryByID(int id, [FromBody] CategoryVM category)
        {
            var updatecategory = _categoriesService.UpdateCategoryByID(id, category);
            return Ok(updatecategory);
        }

        [HttpDelete("delete-category-by-id/{id}")]
        public IActionResult DeleteCategoryByID(int id)
        {
            var deletecategory = _categoriesService.DeleteCategoryByID(id);
            return Ok();
        }
    }
}
