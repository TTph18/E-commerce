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
        
        [HttpPost("add-product")]
        public IActionResult AddProduct([FromBody]ProductVM product)
        {
            _productsService.AddProduct(product);
            return Ok();
        }
    }
}
