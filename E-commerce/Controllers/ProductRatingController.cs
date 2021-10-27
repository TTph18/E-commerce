﻿using E_commerce.Data.Services;
using E_commerce.Data.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

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
        public  IActionResult AddRatingWithProduct([FromForm] RatingCreateRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            _ratingService.AddRatingWithProduct(request);
            return Ok();
        }
    }
}