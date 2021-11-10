using E_commerce.Data.Services;
using E_commerce.Data.ViewModels;
using E_commerce.Shared;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_commerce.Controllers
{
    [Route("api/[controller]")]
    [EnableCors("AllowOrigins")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        public ICategoriesService _categoriesService;
        public CategoriesController(ICategoriesService categoriesService)
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

        [HttpGet("get-category-products/{id}")]
        public IActionResult GetCategoryData(int id)
        {
            var categorydata = _categoriesService.GetCategoryData(id);
            return Ok(categorydata);
        }

        [HttpPost("add-category")]
        //[Authorize(Policy = SecurityConstants.ADMIN_ROLE_POLICY)]
        public IActionResult AddCategory([FromBody] CategoryVM category)
        {
            _categoriesService.AddCategory(category);
            return Ok();
        }

        [HttpPut("update-category-by-id/{id}")]
        //[Authorize(Policy = SecurityConstants.ADMIN_ROLE_POLICY)]
        public IActionResult UpdateCategoryByID(int id, [FromBody] CategoryVM category)
        {
            var updatecategory = _categoriesService.UpdateCategoryByID(id, category);
            return Ok(updatecategory);
        }

        [HttpDelete("delete-category-by-id/{id}")]
        //[Authorize(Policy = SecurityConstants.ADMIN_ROLE_POLICY)]
        public IActionResult DeleteCategoryByID(int id)
        {
            var deletecategory = _categoriesService.DeleteCategoryByID(id);
            return Ok();
        }
    }
}
