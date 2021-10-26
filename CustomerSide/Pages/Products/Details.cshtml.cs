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
        private readonly IMapper _mapper;
        public DetailsModel(IProductServices productService,
            IMapper mapper)
        {
            _productService = productService;
            _mapper = mapper;
        }

        [BindProperty]
        public ProductVM Product { get; set; }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            Product = await _productService.GetProductByIDAsync(id);
            if (Product == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
