 using E_commerce.Data.Services;
using E_commerce.Data.ViewModels;
using E_commerce.Shared.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_commerce.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductRatingController : ControllerBase
    {
        public RatingService _ratingService;
        public ProductRatingController(RatingService ratingService)
        {
            _ratingService = ratingService;
        }
        [HttpGet("get-rating-by-product/{id}")]
        public IActionResult GetRatingByProduct(int id)
        {
            var rating = _ratingService.GetRatingByProducts(id);
            return Ok(rating);
        }

        [HttpPost("add-rating")]
        public async Task<IActionResult> AddRatingWithProductAsync([FromBody] RatingCreateRequest request)
        {
            await _ratingService.AddRatingWithProductAsync(request);
            return Ok();
        }
    }
}
