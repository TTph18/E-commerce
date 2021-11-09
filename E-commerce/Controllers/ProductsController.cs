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
using E_commerce.Shared.DTO.Paging;
using E_commerce.Shared.DTO.Product;
using System.Threading;
using E_commerce.Shared;

namespace E_commerce.Controllers
{
    [Route("api/[controller]")]
    [EnableCors("AllowOrigins")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        public ProductsService _productsService;
        public ProductsController(ProductsService productsService)
        {
            _productsService = productsService;
        }

        [HttpGet("get-all-products")]
        public async Task<ActionResult<PagingResponseDTO<ProductDTO>>> GetAllProductsAsync(
            [FromQuery]ProductCriteriaDTO productCriteriaDto,
            CancellationToken cancellationToken)
        {
            try
            {
                var allproducts = await _productsService.GetProducts(productCriteriaDto, cancellationToken);
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
        [Authorize(Policy = SecurityConstants.ADMIN_ROLE_POLICY)]
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
        [Authorize(Policy = SecurityConstants.ADMIN_ROLE_POLICY)]
        public async Task<IActionResult> UpdateProductByID([FromRoute]int id, [FromForm] ProductCreateRequest request)
        {
            var updateproduct = await _productsService.UpdateProductByIDAsync(id, request);
            return Ok(updateproduct);
        }

        [HttpDelete("delete-product-by-id/{id}")]
        [Authorize(Policy = SecurityConstants.ADMIN_ROLE_POLICY)]
        public IActionResult DeleteProductByID(int id)
        {
            var deleteproduct = _productsService.DeleteProductByID(id);
            return Ok();
        }
    }
}
