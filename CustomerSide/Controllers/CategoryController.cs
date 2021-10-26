using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CustomerSide.Models;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using Microsoft.Extensions.Configuration;
using E_commerce.Shared.ViewModels;
using System.Net;

namespace CustomerSide.Controllers
{
    public class CategoryController : Controller
    {
        HttpClient client;
        private readonly IConfiguration _configuration;
        public CategoryController(IConfiguration configuration)
        {
            client = new HttpClient();
            _configuration = configuration;
        }
        public async Task<IActionResult> Detail(int id)
        {
            CategoryProductVM categoryData = new CategoryProductVM();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync(_configuration["BaseAddress"] + "/api/Categories/get-category-products/" + id))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    categoryData = JsonConvert.DeserializeObject<CategoryProductVM>(apiResponse);
                }
            }
            return View(categoryData.Products);
        }
    }
}
