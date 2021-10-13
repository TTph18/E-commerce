using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CustomerSide.Models;
using System.Net.Http;

namespace CustomerSide.Controllers
{
    public class ProductController : Controller
    {
        public IActionResult Index()
        {
            IEnumerable<ProductsViewModel> products = null;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:44377/api/");
                //HTTP GET
                var responseTask = client.GetAsync("Products");
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<IList<ProductsViewModel>>();
                    readTask.Wait();

                    products = readTask.Result;
                }
                else //web api sent error response 
                {
                    //log response status here..

                    products = Enumerable.Empty<ProductsViewModel>();

                    ModelState.AddModelError(string.Empty, "Server error.");
                }
            }
            return View(products);
        }
    }
}
