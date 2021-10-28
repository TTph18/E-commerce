using E_commerce.Shared.DTO.Paging;
using E_commerce.Shared.DTO.Product;
using E_commerce.Shared.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace CustomerSide.Services
{
    public class ProductRatingServices : IProductRatingServices
    {
        private readonly IConfiguration _configuration;

        public ProductRatingServices(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        
        public async Task<bool> AddRatingByProductAsync(int productID, ProductRatingVM productRating)
        {
            var ratingCreateRequest = new RatingCreateRequest
            {
                ProductID = productRating.ProductID,
                Rating = productRating.Rating
            };
            using (var httpClient = new HttpClient())
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(ratingCreateRequest), Encoding.UTF8, "application/json");

                var response = await httpClient.PostAsync(_configuration["BaseAddress"] + "/api/ProductRating/add-rating", content);
                response.EnsureSuccessStatusCode();
                return await Task.FromResult(true);
            }
        }
    }
}
