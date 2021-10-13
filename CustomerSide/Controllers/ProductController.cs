using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CustomerSide.Models;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using System.Net;

namespace CustomerSide.Controllers
{
    public class ProductController : Controller
    {
        //Hosted web API REST Service base url
        Uri Baseurl = new Uri( "http://localhost:44377/api"); 
        HttpClient client;
        public ProductController()
        {
            client = new HttpClient();
            client.BaseAddress = Baseurl;
        }
        public async Task<IActionResult> Index()
        {
            List<ProductsViewModel> reservationList = new List<ProductsViewModel>();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("https://localhost:44377/api/Products/get-all-products"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    reservationList = JsonConvert.DeserializeObject<List<ProductsViewModel>>(apiResponse);
                }
            }
            return View(reservationList);
        }
    }
}
