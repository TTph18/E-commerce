using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using CustomerSide.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

namespace CustomerSide.Controllers.Components
{
    public class FilterViewComponent : ViewComponent
    {
        HttpClient client;
        private readonly IConfiguration _configuration;
        public FilterViewComponent(IConfiguration configuration)
        {
            client = new HttpClient();
            _configuration = configuration;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var items = await GetCategoriesAsync();
            return View(items);
        }
        public async Task<List<CategoriesViewModel>> GetCategoriesAsync()
        {
            List<CategoriesViewModel> categoryList = new List<CategoriesViewModel>();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync(_configuration["BaseAddress"] + "/api/Categories/get-all-categories"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    categoryList = JsonConvert.DeserializeObject<List<CategoriesViewModel>>(apiResponse);
                }
            }
            return categoryList;
        }
    }
}
