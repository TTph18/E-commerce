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
        public IActionResult GetAllProducts()
        {
            var allproducts = _productsService.GetAllProduct();
            return Ok(allproducts);
        }
        [HttpGet("get-product-by-id/{id}")]
        public IActionResult GetProductByID(int id)
        {
            var product = _productsService.GetProductByID(id);
            return Ok(product);
        }
        [HttpPost("add-product")]
        public IActionResult AddProduct([FromBody]ProductVM product)
        {
            _productsService.AddProduct(product);
            return Ok();
        }
        [HttpPut("update-product-by-id/{id}")]
        public IActionResult UpdateBookByID(int id, [FromBody] ProductVM product)
        {
            var updateproduct = _productsService.UpdateProductByID(id, product);
            return Ok(updateproduct);
        }
        [HttpDelete("delete-product-by-id/{id}")]
        public IActionResult DeleteBookByID(int id)
        {
            var deleteproduct = _productsService.DeleteProductByID(id);
            return Ok();
        }
    }
}
