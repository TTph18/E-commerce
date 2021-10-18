using Microsoft.AspNetCore.Http;
using E_commerce.Data.Services;
using E_commerce.Data.ViewModels;
using Microsoft.AspNetCore.Mvc;
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
            var allproducts = _productsService.GetAllProduct(sortBy, filterString, pageNumber);
            return Ok(allproducts);
        }

        [HttpGet("get-product-by-id/{id}")]
        public IActionResult GetProductByID(int id)
        {
            var product = _productsService.GetProductByID(id);
            return Ok(product);
        }

        [HttpPost("add-product")]
        public IActionResult AddProductWithCategory([FromBody]ProductVM product)
        {
            _productsService.AddProductWithCategory(product);
            return Ok();
        }

        [HttpPut("update-product-by-id/{id}")]
        public IActionResult UpdateProductByID(int id, [FromBody] ProductVM product)
        {
            var updateproduct = _productsService.UpdateProductByID(id, product);
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
