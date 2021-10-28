using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using E_commerce.Shared.ViewModels;
using CustomerSide.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

namespace CustomerSide.Controllers.Components
{
    public class RatingViewComponent : ViewComponent
    {
        private readonly IConfiguration _configuration;
        public RatingViewComponent(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public async Task<IViewComponentResult> InvokeAsync(int id)
        {
            var items = await GetRatingsAsync(id);
            return View(items);
        }
        public async Task<List<ProductRatingVM>> GetRatingsAsync(int id)
        {
            List<ProductRatingVM> ratingList = new List<ProductRatingVM>();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync(_configuration["BaseAddress"] + "/api/ProductRating/get-rating-by-product/"+ id))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    ratingList = JsonConvert.DeserializeObject<List<ProductRatingVM>>(apiResponse);
                }
            }
            return ratingList;
        }
    }
}
