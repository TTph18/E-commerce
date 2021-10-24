using Microsoft.AspNetCore.Http;
using E_commerce.Data.Services;
using E_commerce.Data.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_commerce.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    
    public class ProductsController : ControllerBase
    {
        public ProductsService _productsService;
        public ProductsController(ProductsService productsService)
        {
            _productsService = productsService;
        }

        [HttpGet("get-all-products")]
        public IActionResult GetAllProducts(string sortBy, string filterString, int pageNumber)
        {
            try
            {
                var allproducts = _productsService.GetAllProduct(sortBy, filterString, pageNumber);
                return Ok(allproducts);
            }
            catch(Exception)
            {
                return BadRequest("Sorry we couldnt load products");
            }
        }

        [HttpGet("get-product-by-id/{id}")]
        public IActionResult GetProductByID(int id)
        {
            var product = _productsService.GetProductByID(id);
            return Ok(product);
        }

        [HttpPost("add-product")]
        public async Task<IActionResult> AddProductWithCategory([FromForm]ProductCreateRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var newproduct = await _productsService.AddProductWithCategoryAsync(request);
            return Ok(newproduct);
        }

        [HttpPut("update-product-by-id/{id}")]
        public async Task<IActionResult> UpdateProductByID([FromRoute]int id, [FromForm] ProductCreateRequest request)
        {
            var updateproduct = await _productsService.UpdateProductByIDAsync(id, request);
            return Ok(updateproduct);
        }

        [HttpDelete("delete-product-by-id/{id}")]
        public IActionResult DeleteProductByID(int id)
        {
            var deleteproduct = _productsService.DeleteProductByID(id);
            return Ok();
        }
    }
}
