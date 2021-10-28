using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CustomerSide.Services;
using E_commerce.Shared.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CustomerSide.Pages.Products
{
    public class DetailsModel : PageModel
    {
        private readonly IProductServices _productService;
        private readonly IProductRatingServices _productRatingServices;

        private readonly IMapper _mapper;
        public DetailsModel(IProductServices productService, IProductRatingServices productRatingServices,
            IMapper mapper)
        {
            _productService = productService;
            _productRatingServices = productRatingServices;
            _mapper = mapper;
        }

        [BindProperty]
        public ProductVM Product { get; set; }
        [BindProperty]
        public ProductRatingVM ProductRating { get; set; }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            Product = await _productService.GetProductByIDAsync(id);
            if (Product == null)
            {
                return NotFound();
            }
            return Page();
        }
        public async Task<IActionResult> OnPostAsync(int id)
        {
            if (!ModelState.IsValid || id < 0)
            {
                return NotFound();
            }
            ProductRating = new ProductRatingVM();
            ProductRating.ProductID = id;
            ProductRating.Rating = Convert.ToInt32(Request.Form["Rating"]);
            ProductRatingVM rating = ProductRating;
            if (await _productRatingServices.AddRatingByProductAsync(id, rating))
            {
                return RedirectToPage("./Index");
            }    
            return Page();
        }

    }
}
