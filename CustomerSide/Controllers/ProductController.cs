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
    public class ProductController : Controller
    {
        HttpClient client;
        private readonly IConfiguration _configuration;
        public ProductController(IConfiguration configuration)
        {
            client = new HttpClient();
            _configuration = configuration;
        }
        public async Task<IActionResult> Index()
        {
            List<ProductVM> productList = new List<ProductVM>();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync(_configuration["BaseAddress"] + "/api/Products/get-all-products"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    productList = JsonConvert.DeserializeObject<List<ProductVM>>(apiResponse);
                }
            }
            return View(productList);
        }
        public async Task<IActionResult> Detail(int id)
        {
            ProductVM product = new ProductVM();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync(_configuration["BaseAddress"] + "/api/Products/get-product-by-id/"+ id))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    product = JsonConvert.DeserializeObject<ProductVM>(apiResponse);
                }
            }
            return View(product);
        }
    }
}
