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
    public class RatingBoxViewComponent : ViewComponent
    {
        private readonly IConfiguration _configuration;
        public RatingBoxViewComponent(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public async Task<IViewComponentResult> InvokeAsync(int id)
        {
            var items = await AddRatingsAsync(id);
            return View(items);
        }
        public async Task<IActionResult> AddRatingsAsync(int id)
        {
            List<ProductRatingVM> ratingList = new List<ProductRatingVM>();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync(_configuration["BaseAddress"] + "/api/ProductRating/get-rating-by-product/" + id))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    ratingList = JsonConvert.DeserializeObject<List<ProductRatingVM>>(apiResponse);
                }
            }
            return ratingList;
        }
    }
}
