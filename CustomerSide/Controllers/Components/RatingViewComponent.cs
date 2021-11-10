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
using CustomerSide.Services;

namespace CustomerSide.Controllers.Components
{
    public class RatingViewComponent : ViewComponent
    {
        private readonly IProductRatingServices _productRatingServices;
        public RatingViewComponent(IProductRatingServices productRatingServices)
        {
            _productRatingServices = productRatingServices;
        }
        public async Task<IViewComponentResult> InvokeAsync(int id)
        {
            var items = await _productRatingServices.GetRatingsAsync(id);
            return View(items);
        }
        
    }
}
